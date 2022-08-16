using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

namespace Assets.Scripts.MessageBroker
{
    public class MyAssetPostProcessor : AssetPostprocessor
    {
        public static void OnPostprocessAllAsset(string[] importedAssets, string[] deletedAssets,
            string[] movedAssets, string[] movedFromAssetPaths)
        {
            var gen = new MessageBrokerGenerator();
            gen.Generate();
        }
    }
    internal class MessageBrokerGenerator
    {
        public readonly string ClassName = "MessageBroker";
        public readonly string Namespace = "Assets.Scripts.MessageBroker";
        public readonly string OutputPath = $"Assets/Scripts/MessageBroker/MessageBroker.{0}.cs";
        public readonly string NL = "\r\n";

        private static class Indent
        {
            private static int count = 0;
            private static readonly char indChar = '\t';

            public static string Get() => new string(indChar, count);
            public static string Push() { count++; return Get(); }
            public static string Pop() { count--; count = Math.Max(0, count); return Get(); }
        }

        public void Generate()
        {
            MessageInfo[] messageInfos = GetAllMessages();

            var sb = new StringBuilder();
            this.AddUsings(sb);
            this.OpenNamespace(sb);

            this.OpenClassDeclaration(sb);

            this.AddPrivateVariables(messageInfos, sb);

            this.AddStart(messageInfos, sb);

            foreach(var message in messageInfos)
            {
                this.AddMessageBlock(message, sb);
            }

            this.CloseClassDeclaration(sb);
            this.CloseNamespace(sb);

            System.IO.File.WriteAllText(OutputPath, sb.ToString());
        }

        private void AddUsings(StringBuilder sb)
        {
            sb.AppendLine($"using UnityEngine;{NL}");
            sb.AppendLine($"using UnityEditor;{NL}");
        }

        private void OpenNamespace(StringBuilder sb)
        {
            sb.AppendLine($"namespace {Namespace}");
            sb.AppendLine($"{{");
        }

        private void CloseNamespace(StringBuilder sb)
        {
            sb.AppendLine($"{Indent.Pop()}}}");
        }

        private void OpenClassDeclaration(StringBuilder sb)
        {
            sb.AppendLine($"{Indent.Push()}public partial class {ClassName}");
            sb.AppendLine($"{Indent.Get()}{{");
        }

        private void AddPrivateVariables(MessageInfo[] messageInfos, StringBuilder sb)
        {
            Indent.Push();
            foreach (var messageInfo in messageInfos)
            {
                sb.AppendLine($"{Indent.Get()}private {nameof(RequestMessage)} m_{this.CleanName(messageInfo.Message.name)};");
            }
            Indent.Pop();
        }

        private void AddStart(MessageInfo[] messageInfos, StringBuilder sb)
        {
            sb.AppendLine($"{Indent.Push()}void Start()");
            sb.AppendLine($"{Indent.Get()}{{");
            Indent.Push();
            foreach(var messageInfo in messageInfos)
            {
                sb.AppendLine($"{Indent.Get()}this.m_{CleanName(messageInfo.Message.name)} = AssetDatabase.LoadAssetAtPath<{nameof(RequestMessage)}>(\"{messageInfo.Path}\");");
            }
            Indent.Pop();
            sb.AppendLine($"{Indent.Get()}}}");
            Indent.Pop();
        }


        private string CleanName(string name)
        {
            return System.Text.RegularExpressions.Regex.Replace(name, @"[^a-zA-Z0-9_]", String.Empty);
        }

        private void AddMessageBlock(MessageInfo messageInfo, StringBuilder sb)
        {
            var name = CleanName(messageInfo.Message.name);
            sb.AppendLine($"{Indent.Push()}public object Send_{name}(RequestMessagePayload payload)");
            sb.Append($"{Indent.Get()}{{{NL}");

            

            sb.Append($"{Indent.Push()}return null;{NL}");
            sb.Append($"{Indent.Pop()}}}{NL}");
            Indent.Pop();
        }

        private void CloseClassDeclaration(StringBuilder sb)
        {
            sb.AppendLine($"{Indent.Get()}}}");
        }



        private MessageInfo[] GetAllMessages()
        {
            string[] guids = AssetDatabase.FindAssets("t:" + typeof(RequestMessage).Name);
            var messageInfos = new MessageInfo[guids.Length];
            for (int i = 0; i < guids.Length; i++)         //probably could get optimized 
            {
                string path = AssetDatabase.GUIDToAssetPath(guids[i]);
                messageInfos[i] = new MessageInfo()
                {
                    Message = AssetDatabase.LoadAssetAtPath<RequestMessage>(path),
                    Path = path
                };
            }
            return messageInfos;
        }


        private string FindMessageBrokerPath()
        {
            var assetIds = AssetDatabase.FindAssets(nameof(MessageBroker));
            foreach (var assetId in assetIds)
            {
                var path = AssetDatabase.GUIDToAssetPath(assetId);
                var asset = AssetDatabase.LoadAssetAtPath<MessageBroker>(path);
                if (asset != null)
                {
                    return path;
                }
            }
            return null;
        }

        private class MessageInfo
        {
            public RequestMessage Message;
            public string Path;
        }
    }
}
