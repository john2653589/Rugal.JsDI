using Microsoft.AspNetCore.Html;
using System.Text.Json;

namespace Rugal.JavaScriptDataInject.Service
{
    public class JsDIService
    {
        public const string JsStoreKey = "JsStore";
        public const string QueryKey = "Query";
        public Dictionary<string, Dictionary<string, object>> JsStore { get; private set; }
        public JsDIService()
        {
            JsStore = [];
            WithDefaultStore(JsStoreKey);
            WithDefaultStore(QueryKey);
        }
        public IHtmlContent RenderJs()
        {
            var JsVars = new List<string> { };
            foreach (var Store in JsStore)
            {
                var Js = $"const {Store.Key} = {JsonSerializer.Serialize(Store.Value)};";
                JsVars.Add(Js);
            }
            var JsResult = string.Join('\n', JsVars);
            var Result = new HtmlString(JsResult);
            return Result;
        }
        public JsDIService AddStore(string StoreKey, string Key, object Value)
        {
            BaseAdd(StoreKey, Key, Value);
            return this;
        }
        public JsDIService AddStore(string Key, object Value)
        {
            BaseAdd("JsStore", Key, Value);
            return this;
        }
        public JsDIService RemoveStore(string StoreKey, string Key)
        {
            BaseRemove(StoreKey, Key);
            return this;
        }
        public JsDIService RemoveStore(string Key)
        {
            BaseRemove(JsStoreKey, Key);
            return this;
        }
        public JsDIService AddQuery(string Key, object Value)
        {
            BaseAdd("Query", Key, Value);
            return this;
        }
        public JsDIService RemoveQuery(string Key)
        {
            BaseRemove(QueryKey, Key);
            return this;
        }
        public JsDIService WithDefaultStore(string StoreKey)
        {
            JsStore.Add(StoreKey, []);
            return this;
        }
        private void BaseAdd(string StoreKey, string Key, object Value)
        {
            if (!JsStore.TryGetValue(StoreKey, out var Store))
            {
                Store = [];
                JsStore.Add(StoreKey, Store);
            }
            if (!Store.TryAdd(Key, Value))
                Store[Key] = Value;
        }
        private void BaseRemove(string StoreKey, string Key)
        {
            if (!JsStore.TryGetValue(StoreKey, out var Store))
                return;

            Store.Remove(Key);
        }
    }
}