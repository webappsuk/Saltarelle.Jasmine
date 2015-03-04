﻿using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

[assembly: PreserveMemberCase]

#pragma warning disable 1591   // disables missing XML documentation warning

namespace Jasmine
{
    [Imported]
    public class Matchers
    {
        private Matchers(Env env, object actual, Env spec, bool isNot = false) { }

        public Env env;
        public object actual;
        public Env spec;
        public bool isNot = false;
        public object message()
        {
            return null;
        }

        public bool toBe(object expected) { return false; }
        public bool toEqual(object expected) { return false; }
        public bool toMatch(string expected) { return false; }
        public bool toBeDefined() { return false; }
        public bool toBeUndefined() { return false; }
        public bool toBeNull() { return false; }
        public bool toBeNaN() { return false; }
        public bool toBeTruthy() { return false; }
        public bool toBeFalsy() { return false; }
        public bool toHaveBeenCalled() { return false; }
        [ExpandParams]
        public bool toHaveBeenCalledWith(params object[] par) { return false; }
        public bool toContain(object expected) { return false; }
        public bool toBeLessThan(object expected) { return false; }
        public bool toBeGreaterThan(object expected) { return false; }
        public bool toBeCloseTo(object expected, int precision) { return false; }
        public bool toThrow() { return false; }
        public bool toThrowError() { return false; }
        public bool toThrowError(object expected) { return false; }

        [IntrinsicProperty]
        public Matchers not { get { return null; } }
        
        public IAny Any;
    }

    [Imported]
    public interface ICustomMatcher
    {
        //can't make a compare method here as an classes that implement the generic will complain that they don't implement the non-generic compare
    }

    [Imported]
    public interface ICustomMatcher<in T> : ICustomMatcher
    {
       IMatcherResult compare(object actual, T expect);
    }

    [Imported]
    public interface IMatcherResult
    {
        // To return custom matcher results, you need to implement a class such as the one below and use it as the return type of the compare method in the matcher
        //[PreserveMemberCase(false)]
        //public class MatcherResult : IMatcherResult
        //{
        //    public bool Pass;
        //    public string Message;

        //    public MatcherResult(bool pass, string message)
        //    {
        //        Pass = pass;
        //        Message = message;
        //    }
        //}
    }
    
    [Imported]    
    public interface ICustomMatcherUtil
    {
        [PreserveName] string buildFailureMessage();
        [PreserveName] bool contains(object haystack, object needle, object customTesters);
        [PreserveName] bool equals(object a, object b, object customTesters);
    }

    [Imported]
    public class Spy
    {
        public string identity;
        public ICalls calls;
        public ISpyAnd and;
        [InlineCode("{this}({*args})")]
        public void Call(params object[] args) { }

        [ScriptSkip]
        public static implicit operator Function(Spy spy)
        {
            return new Function();
        }
    }

    [IgnoreNamespace]
    [Imported]
    [ScriptName("Object")]
    public class JasmineSuite
    {
        [InlineCode("{}")]
        public JasmineSuite() { }

        [InlineCode("describe({description},{specDefinitions})")]
        public static void describe(string description, Action specDefinitions) { }

        [InlineCode("fdescribe({description},{specDefinitions})")]
        public static void fdescribe(string description, Action specDefinitions) { }

        [InlineCode("xdescribe({description},{specDefinitions})")]
        public static void xdescribe(string description, Action specDefinitions) { }

        [InlineCode("it({desc})")]
        public static void it(string desc) { }

        [InlineCode("it({desc},{func})")]
        public static void it(string desc, Action func) { }

        [InlineCode("it({desc},{func})")]
        public static void it(string desc, Action<Action> func) { }

        [InlineCode("it({desc},{func},{timeout})")]
        public static void it(string desc, Action<Action> func, int timeout) { }

        [InlineCode("it({desc}, ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void it(string desc, Func<Task> func) { }

        [InlineCode("it({desc}, ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}), {timeout})")]
        public static void it(string desc, Func<Task> func, int timeout) { }

        [InlineCode("fit({desc},{func})")]
        public static void fit(string desc, Action func) { }

        [InlineCode("fit({desc},{func})")]
        public static void fit(string desc, Action<Action> func) { }

        [InlineCode("fit({desc},{func},{timeout})")]
        public static void fit(string desc, Action<Action> func, int timeout) { }

        [InlineCode("fit({desc}, ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void fit(string desc, Func<Task> func) { }

        [InlineCode("fit({desc}, ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}),{timeout})")]
        public static void fit(string desc, Func<Task> func, int timeout) { }

        [InlineCode("xit({desc},{func})")]
        public static void xit(string desc, Action func) { }

        [InlineCode("xit({desc},{func})")]
        public static void xit(string desc, Action<Action> func) { }

        [InlineCode("xit({desc},{func},{timeout})")]
        public static void xit(string desc, Action<Action> func, int timeout) { }

        [InlineCode("xit({desc}, ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void xit(string desc, Func<Task> func) { }

        [InlineCode("xit({desc}, ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}),{timeout})")]
        public static void xit(string desc, Func<Task> func, int timeout) { }

        [InlineCode("pending()")]
        public static void pending() { }

        [InlineCode("pending({reason})")]
        public static void pending(string reason) { }

        [InlineCode("expect({o})")]
        public static Matchers expect(object o) { return null; }

        [InlineCode("expect({d})")]
        public static Matchers expect(Delegate d) { return null; }

        [InlineCode("beforeEach({func})")]
        public static void beforeEach(Action func) { }

        [InlineCode("beforeEach({func})")]
        public static void beforeEach(Action<Action> func) { }

        [InlineCode("beforeEach({func},{timeout})")]
        public static void beforeEach(Action<Action> func, int timeout) { }

        [InlineCode("beforeEach(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void beforeEach(Func<Task> func) { }

        [InlineCode("beforeEach(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}),{timeout})")]
        public static void beforeEach(Func<Task> func, int timeout) { }

        [InlineCode("afterEach({func})")]
        public static void afterEach(Action func) { }

        [InlineCode("afterEach({func})")]
        public static void afterEach(Action<Action> func) { }

        [InlineCode("afterEach({func},{timeout})")]
        public static void afterEach(Action<Action> func, int timeout) { }

        [InlineCode("afterEach(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void afterEach(Func<Task> func) { }

        [InlineCode("afterEach(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}),{timeout})")]
        public static void afterEach(Func<Task> func, int timeout) { }

        [InlineCode("beforeAll({func})")]
        public static void beforeAll(Action func) { }

        [InlineCode("beforeAll({func})")]
        public static void beforeAll(Action<Action> func) { }

        [InlineCode("beforeAll({func},{timeout})")]
        public static void beforeAll(Action<Action> func, int timeout) { }

        [InlineCode("beforeAll(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void beforeAll(Func<Task> func) { }

        [InlineCode("beforeAll(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}),{timeout})")]
        public static void beforeAll(Func<Task> func, int timeout) { }

        [InlineCode("afterAll({func})")]
        public static void afterAll(Action func) { }

        [InlineCode("afterAll({func})")]
        public static void afterAll(Action<Action> func) { }

        [InlineCode("afterAll({func},{timeout})")]
        public static void afterAll(Action<Action> func, int timeout) { }

        [InlineCode("afterAll(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void afterAll(Func<Task> func) { }

        [InlineCode("afterAll(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}),{timeout})")]
        public static void afterAll(Func<Task> func, int timeout) { }

        [InlineCode("spyOn({o},{methodname})")]
        public static Spy spyOn(object o, string methodname) { return null; }

        [InlineCode("jasmine.createSpy({name})")]
        public static Jasmine.Spy createSpy(string name)
        {
            return null;
        }

        [InlineCode("jasmine.createSpy({name},{originalFunction})")]
        public static Jasmine.Spy createSpy(string name, Delegate originalFunction)
        {
            return null;
        }

        [InlineCode("jasmine.createSpyObj({baseName}, {methodNames})")]
        public static dynamic createSpyObj(string baseName, string[] methodNames)
        {
            return null;
        }

        [InlineCode("jasmine.createSpyObj({baseName}, {methodNames})")]
        public static T createSpyObj<T>(string baseName, string[] methodNames)
        {
            return default(T);
        }

        // clock mock

        // async support
        
        /*
        // runs, waits, waitsFor removed from Jasmine 2
        [InlineCode("runs({func})")]
        public static void runs(Action func) { }

        [InlineCode("waitsFor({func},{failureMessage},{timeout})")]
        public static void waitsFor(Func<bool> func, string failureMessage, int timeout) { }

        [InlineCode("waitsFor({func},'',{timeout})")]
        public static void waitsFor(Func<bool> func, int timeout) { }

        [InlineCode("waitsFor({func})")]
        public static void waitsFor(Func<bool> func) { }
        */

        [InlineCode("jasmine.clock()")]
        public static Clock clock()
        {
            return null;
        }

        [InlineCode("jasmine.Spec()")]
        public static Spec Spec()
        {
            return null;
        }
        
        [InlineCode("jasmine.any({any})")]
        public static IAny any(object any)
        {
            return null;
        }

        [InlineCode("jasmine.objectContaining({sample})")]
        public static IObjectContaining objectContaining(object sample)
        {
            return null;
        }

        [InlineCode("jasmine.pp({value})")]
        public static string pp(object value)
        {
            return null;
        }

        [InlineCode("jasmine.getEnv()")]
        public static Env getEnv()
        {
            return null;
        }

        [InlineCode("jasmine.addMatchers({matcher})")]
        public static void addMatchers(JsDictionary<string, Func<ICustomMatcherUtil, object, ICustomMatcher>> matcher) { }

        [InlineCode("jasmine.addCustomEqualityTester({customEquality})")]
        public static void addCustomEqualityTester(object customEquality) { }
        
        [Imported]
        public static class Util
        {
            public static object argsToArray(object args)
            {
                return null;
            }
            public static bool arrayContains(Array array, object contains)
            {
                return false;
            }
            public static object clone(object obj)
            {
                return null;
            }
            public static string htmlEscape(string str)
            {
                return null;
            }
            public static object inherit(Function childClass, Function parentClass)
            {
                return null;
            }
            public static bool isUndefined(object obj)
            {
                return false;
            }
        }
        
        public static double DEFAULT_TIMEOUT_INTERVAL 
        {
            [InlineCode("jasmine.DEFAULT_TIMEOUT_INTERVAL")]
            get { return 5000; }
            [InlineCode("jasmine.DEFAULT_TIMEOUT_INTERVAL = {value}")]
            set { }
        }
    }

    [Imported]
    public class Clock
    {
        public void install() { }        
        public void uninstall() { }        
        public void tick(int ms) { }
    }

    [Imported]
    public interface IAny
    {
        object IAny(object exportedClass);

        bool jasmineMatches(object other);
        string jasmineToString();
    }

    [Imported]
    public interface IObjectContaining
    {
        object IObjectContaining(object sample);

        bool jasmineMatches(object other, object[] mismatchKeys, object[] mismatchValues);
        string jasmineToString();
    }

    [Imported]
    public interface IBlock
    {
        object Block(Env env, SpecFunction func, Spec spec);

        void execute(Action onComplete);
    }

    [Imported]
    public interface IWaitsBlock : IBlock
    {
        object WaitsBlock(Env env, int timeout, Spec spec);
    }

    [Imported]
    public interface IWaitsForBlock : IBlock
    {
        object WaitsBlock(Env env, int timeout, SpecFunction latchFunction, string message, Spec spec);
    }

    [Imported]
    public sealed class Env
    {
        private Env() { }

        public Func<Function, int, int> setTimeout;
        public Action<int> clearTimeout;
        public object setInterval;
        public Action<int> clearInterval;
        public int updateInterval;

        public Spec currentSpec;

        public Matchers matchersClass;

        public object version()
        {
            return null;
        }

        public string versionString()
        {
            return null;
        }
        public int nextSpecId()
        {
            return 0;
        }
        public void addReporter(IJsApiReporter reporter) { }
        public void execute() { }
        public Suite describe(string description, Action specDefinitions)
        {
            return null;
        }
        public void beforeEach(Action beforeEachFunction){}
        public void beforeAll(Action beforeAllFunction){}
        public IRunner currentRunner()
        {
            return null;
        }
        public void afterEach(Action afterEachFunction){}
        public void afterAll(Action afterAllFunction){}
        public IXSuite xdescribe(string desc, Action specDefinitions)
        {
            return null;
        }
        public Spec it(string description, Action func)
        {
            return null;
        }
        public XSpec xit(string desc, Action func)
        {
            return null;
        }
        public bool compareRegExps_(Regex a, Regex b, string[] mismatchKeys, string[] mismatchValues)
        {
            return false;
        }
        public bool compareObjects_(object a, object b, string[] mismatchKeys, string[] mismatchValues)
        {
            return false;
        }
        public bool equals_(object a, object b, string[] mismatchKeys, string[] mismatchValues)
        {
            return false;
        }
        public bool contains_(object haystack, object needle)
        {
            return false;
        }
        public void addEqualityTester(Func<object, object, Env, string[], string[], bool> equalityTester) { }
        public bool specFilter(Spec spec)
        {
            return false;
        }
    }

    [Imported]
    public interface IFakeTimer
    {
        object FakeTimer();

        Action reset();
        Action tick(int millis);
        Action runFunctionsWithinRange(int oldMillis, int nowMillis);
        Action scheduleFunction(object timeoutKey, Action funcToCall, int millis, bool recurring);
    }

    [Imported]
    public interface IHtmlReporter
    {
        object HtmlReporter();
    }

    [Imported]
    public interface IHtmlSpecFilter
    {
        object HtmlSpecFilter();
    }

    [Imported]
    public abstract class Result
    {
        protected Result() {}
        public string type;
    }

    [Imported]
    public sealed class NestedResults : Result
    {
        private NestedResults() { }

        string description;

        public int totalCount;
        public int passedCount;
        public int failedCount;

        public bool skipped;

        public void rollupCounts(NestedResults result) { }
        public void log(object values) { }
        public Result[] getItems()
        {
            return null;
        }
        public void addResult(Result result) { }

        public bool passed()
        {
            return false;
        }
    }

    [Imported] 
    public sealed class MessageResult : Result
    {
        private MessageResult() { }

        public object values;
        public Trace trace;
    }

    [Imported]
    public sealed class ExpectationResult : Result
    {
        private ExpectationResult() { }

        public string matcherName;

        public bool passed()
        {
            return false;
        }
        public object expected;
        public object actual;
        public string message;
        public Trace trace;
    }

    [Imported]
    public class Trace
    {
        public string name;
        public string message;
        public object stack;
    }

    [Imported]
    public interface IPrettyPrinter
    {
        object PrettyPrinter();

        void format(object value);
        void iterateObject(object obj, Action<string, bool> fn);
        void emitScalar(object value);
        void emitString(string value);
        void emitArray(object[] array);
        void emitObject(object obj);
        void append(object value);
    }

    [Imported]
    public interface IStringPrettyPrinter : IPrettyPrinter
    {
    }

    [Imported]
    public class Queue
    {
        private Queue(object env){ }

        public Env env;
        public bool[] ensured;
        public IBlock[] blocks;
        public bool running;
        public int index;
        public int offset;
        public bool abort;

        public void addBefore(IBlock block) { }
        public void addBefore(IBlock block, bool ensure) { }
        public void add(object block) { }
        public void add(object block, bool ensure) { }
        public void insertNext(object block) { }
        public void insertNext(object block, bool ensure) { }
        public void start() { }
        public void start(Action onComplete) { }
        public bool isRunning()
        {
            return false;
        }
        public void next_() { }

        public NestedResults results()
        {
            return null;
        }
    }

    [Imported]
    public interface IReporter
    {
        void reportRunnerStarting(IRunner runner);
        void reportRunnerResults(IRunner runner);
        void reportSuiteResults(Suite suite);
        void reportSpecStarting(Spec spec);
        void reportSpecResults(Spec spec);
        void log(string str);
    }

    [Imported]
    public interface IMultiReporter : IReporter
    {
        void addReporter(IReporter reporter);
    }

    [Imported]
    public interface IRunner
    {
        object Runner(Env env);

        void execute();
        void beforeEach(SpecFunction beforeEachFunction);
        void afterEach(SpecFunction afterEachFunction);
        void beforeAll(SpecFunction beforeAllFunction);
        void afterAll(SpecFunction afterAllFunction);
        void finishCallback();
        void addSuite(Suite suite);
        void add(IBlock block);
        Spec[] specs();
        Suite[] suites();
        Suite[] topLevelSuites();
        NestedResults results();
    }
    
    public delegate void SpecFunction(Spec spec = null);

    [Imported]
    public class SuiteOrSpec
    {
        public int id;
        public Env env;
        public string description;
        public Queue queue;
    }

    [Imported]
    public class Spec : SuiteOrSpec
    {
        private Spec(Env env, Suite suite, string description) { }

        public Suite suite;

        public SpecFunction[] afterCallbacks;
        public Spy[] spies_;

        public NestedResults results_;
        public Matchers matchersClass;

        public string getFullName()
        {
            return null;
        }
        public NestedResults results()
        {
            return null;
        }
        public object log(object arguments)
        {
            return null;
        }
        public Spec runs(SpecFunction func)
        {
            return null;
        }
        public void addToQueue(IBlock block) { }
        public void addMatcherResult(Result result) { }
        public object expect(object actual)
        {
            return null;
        }
        public Spec waits(int timeout)
        {
            return null;
        }
        public Spec waitsFor(SpecFunction latchFunction, string timeoutMessage = null, int timeout = 0)
        {
            return null;
        }
        public void fail() { }
        public void fail(object e) { }
        public Matchers getMatchersClass_()
        {
            return null;
        }
        public void addMatchers(object matchersPrototype) { }
        public void finishCallback() { }
        public void finish() { }
        public void finish(Action onComplete) { }
        public void after(SpecFunction doAfter) { }
        public object execute()
        {
            return null;
        }
        public object execute(Action onComplete)
        {
            return null;
        }
        public void addBeforesAndAftersToQueue() { }
        public void explodes() { }
        public Spy spyOn(object obj, string methodName, bool ignoreMethodDoesntExist)
        {
            return null;
        }
        public void removeAllSpies() { }
    }

    [Imported]
    public class XSpec
    {
        private XSpec() { }

        public int id;
        public void runs() { }
    }

    [Imported]
    public class Suite : SuiteOrSpec
    {
        private Suite(Env env, string description, Action specDefinitions, Suite parentSuite) { }

        public Suite parentSuite;

        public string getFullName()
        {
            return null;
        }
        public void finish() { }
        public void finish(Action onComplete) { }
        public void beforeEach(SpecFunction beforeEachFunction) { }
        public void afterEach(SpecFunction afterEachFunction) { }
        public void beforeAll(SpecFunction beforeAllFunction) { }
        public void afterAll(SpecFunction afterAllFunction) { }
        public NestedResults results()
        {
            return null;
        }
        public void add(SuiteOrSpec suiteOrSpec) { }
        public Spec[] specs()
        {
            return null;
        }
        public Suite[] suites()
        {
            return null;
        }
        public object[] children()
        {
            return null;
        }
        public void execute() { }
        public void execute(Action onComplete) { }
    }

    [Imported]
    public interface IXSuite
    {
        void execute();
    }

    [Imported]
    public interface ISpyAnd
    {
        string identity();
        Spy callThrough();
        Spy returnValue(object val);
        Spy callFake(Function fn);
        void throwError(string msg);
        Spy stub();
    }

    [Imported]
    public interface ICalls
    {
        bool any();
        int count();
        object[] argsFor(int index);
        object[][] allArgs();
        SpyCall[] all();
        SpyCall mostRecent();
        SpyCall first();
        void reset();
    }

    [Imported]
    [PreserveMemberCase(false)]
    public sealed class SpyCall
    {
        private SpyCall() { }

        public object[] Args;
        public object Object;
    }

    [Imported]
    public interface IJsApiReporter
    {
        void jasmineStarted(ReporterSuiteInfo suiteInfo);
        void jasmineDone();
        void suiteStarted(ReporterResult result);
        void suiteDone(ReporterResult result);
        void specDone(ReporterResult result);
    }
    
    [Imported]
    public sealed class ReporterSuiteInfo
    {
        public int totalSpecsDefined;
    }

    [Imported]
    public sealed class ReporterResult
    {
        public int id;
        public string fullName;
        public string description;
        public string status;
        public ReporterError[] failedExpectations;
    }

    [Imported]
    public sealed class ReporterError
    {
        public int id;
        public string stack;
        public string message;
    }
}