using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

#pragma warning disable 1591   // disables missing XML documentation warning

namespace Jasmine
{
    [Imported]
    public class Matchers
    {
        private Matchers(Env env, object actual, Env spec, bool isNot = false) { }

        public Env Env;
        public object Actual;
        public Env Spec;
        public bool IsNot = false;
        public object Message()
        {
            return null;
        }

        public bool ToBe(object expected) { return false; }
        public bool ToEqual(object expected) { return false; }
        public bool ToMatch(string expected) { return false; }
        public bool ToBeDefined() { return false; }
        public bool ToBeUndefined() { return false; }
        public bool ToBeNull() { return false; }
        public bool ToBeNaN() { return false; }
        public bool ToBeTruthy() { return false; }
        public bool ToBeFalsy() { return false; }
        public bool ToHaveBeenCalled() { return false; }
        [ExpandParams]
        public bool ToHaveBeenCalledWith(params object[] par) { return false; }
        public bool ToContain(object expected) { return false; }
        public bool ToBeLessThan(object expected) { return false; }
        public bool ToBeGreaterThan(object expected) { return false; }
        public bool ToBeCloseTo(object expected, int precision) { return false; }
        public bool ToThrow() { return false; }
        public bool toThrowError() { return false; }
        public bool toThrowError(object expected) { return false; }

        [IntrinsicProperty]
        public Matchers Not { get { return null; } }
        
        public IAny Any;

        // typeof matcher?
    }
    
    public delegate IMatcherResult CustomMatcherComparer(
        CustomMatcherUtil util,
        object customEqualityTesters,
        object actual, 
        object expected);

    [Imported]
    public interface IMatcherResult
    {
        // To return custom matcher results, you need to implement a class such as the one below and use it as the return type of the compare method in the matcher
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
    public sealed class CustomMatcherUtil
    {
        /// <summary>
        /// Prevent instantiation of utilities class which is provided by Jasmine directly.
        /// </summary>
        private CustomMatcherUtil()
        {
        }

        [PreserveName]
        public string BuildFailureMessage() { return null; }

        [PreserveName]
        public bool Contains(object haystack, object needle, object customTesters) { return false; }

        [PreserveName]
        public bool Equals(object a, object b, object customTesters) { return false; }
    }

    [Imported]
    public class Spy
    {
        public string Identity;
        public ICalls Calls;
        public ISpyAnd And;
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
        public static void Describe(string description, Action specDefinitions) { }

        [InlineCode("fdescribe({description},{specDefinitions})")]
        public static void FDescribe(string description, Action specDefinitions) { }

        [InlineCode("xdescribe({description},{specDefinitions})")]
        public static void XDescribe(string description, Action specDefinitions) { }

        [InlineCode("it({desc},{func})")]
        public static void It(string desc, Action func) { }

        [InlineCode("it({desc},{func})")]
        public static void It(string desc, Action<Action> func) { }

        [InlineCode("it({desc}, ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void It(string desc, Func<Task> func) { }

        [InlineCode("fit({desc},{func})")]
        public static void FIt(string desc, Action func) { }

        [InlineCode("fit({desc},{func})")]
        public static void FIt(string desc, Action<Action> func) { }

        [InlineCode("fit({desc}, ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void FIt(string desc, Func<Task> func) { }

        [InlineCode("xit({desc},{func})")]
        public static void XIt(string desc, Action func) { }

        [InlineCode("xit({desc},{func})")]
        public static void XIt(string desc, Action<Action> func) { }

        [InlineCode("xit({desc}, ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void XIt(string desc, Func<Task> func) { }

        [InlineCode("pending()")]
        public static void Pending() { }

        [InlineCode("expect({o})")]
        public static Matchers Expect(object o) { return null; }

        [InlineCode("expect({d})")]
        public static Matchers Expect(Delegate d) { return null; }

        [InlineCode("beforeEach({func})")]
        public static void BeforeEach(Action func) { }

        [InlineCode("beforeEach({func})")]
        public static void BeforeEach(Action<Action> func) { }

        [InlineCode("beforeEach(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void BeforeEach(Func<Task> func) { }

        [InlineCode("afterEach({func})")]
        public static void AfterEach(Action func) { }

        [InlineCode("afterEach({func})")]
        public static void AfterEach(Action<Action> func) { }

        [InlineCode("afterEach(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void AfterEach(Func<Task> func) { }

        [InlineCode("beforeAll({func})")]
        public static void BeforeAll(Action func) { }

        [InlineCode("beforeAll({func})")]
        public static void BeforeAll(Action<Action> func) { }

        [InlineCode("beforeAll(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void BeforeAll(Func<Task> func) { }

        [InlineCode("afterAll({func})")]
        public static void AfterAll(Action func) { }

        [InlineCode("afterAll({func})")]
        public static void AfterAll(Action<Action> func) { }

        [InlineCode("afterAll(ss.mkdel(this, function(done) {{ {func}().continueWith(done); }}))")]
        public static void AfterAll(Func<Task> func) { }

        [InlineCode("spyOn({o},{methodname})")]
        public static Spy SpyOn(object o, string methodname) { return null; }

        [InlineCode("jasmine.createSpy({name})")]
        public static Spy CreateSpy(string name)
        {
            return null;
        }
        public static Spy CreateSpy(string name, Delegate originalFunction)
        {
            return null;
        }

        [InlineCode("jasmine.createSpyObj({baseName}, {methodNames})")]
        public static dynamic CreateSpyObj(string baseName, string[] methodNames)
        {
            return null;
        }

        [InlineCode("jasmine.createSpyObj({baseName}, {methodNames})")]
        public static T CreateSpyObj<T>(string baseName, string[] methodNames)
        {
            return default(T);
        }

        // clock mock

        // async support
        [InlineCode("runs({func})")]
        public static void Runs(Action func) { }

        [InlineCode("waitsFor({func},{failureMessage},{timeout})")]
        public static void WaitsFor(Func<bool> func, string failureMessage, int timeout) { }

        [InlineCode("waitsFor({func},'',{timeout})")]
        public static void WaitsFor(Func<bool> func, int timeout) { }

        [InlineCode("waitsFor({func})")]
        public static void WaitsFor(Func<bool> func) { }

        [InlineCode("jasmine.clock()")]
        public static Clock Clock()
        {
            return null;
        }

        [InlineCode("jasmine.Spec()")]
        public static Spec Spec()
        {
            return null;
        }
        
        [InlineCode("jasmine.any({any})")]
        public static IAny Any(object any)
        {
            return null;
        }

        [InlineCode("jasmine.objectContaining({sample})")]
        public static IObjectContaining ObjectContaining(object sample)
        {
            return null;
        }

        [InlineCode("jasmine.pp({value})")]
        public static string Pp(object value)
        {
            return null;
        }

        [InlineCode("jasmine.getEnv()")]
        public static Env GetEnv()
        {
            return null;
        }

        [InlineCode("(function(){{var $m={matchers}; jasmine.addMatchers(Object.keys($m).reduce(function($acc,$key){{ $acc[$key]=function($u, $c) {{ return {{ compare: function($a, $e) {{ return $m[$key]($u, $c, $a, $e); }} }}; }}; return $acc; }}, {{}}));}})()")]
        public static void AddMatchers(JsDictionary<string, CustomMatcherComparer> matchers) { }

        [InlineCode("(function(){{var $n={name}, $m={matcher}, $o={}; $o[$n]=function($u, $c) {{ return {{ compare: function($a, $e) {{ return $m($u, $c, $a, $e); }} }}; }}; jasmine.addMatchers($o);}})()")]
        public static void AddMatcher(string name, CustomMatcherComparer matcher) { }

        [InlineCode("jasmine.addCustomEqualityTester({customEquality})")]
        public static void AddCustomEqualityTester(object customEquality) { }
        
        [Imported]
        public static class Util
        {

            public static object ArgsToArray(object args)
            {
                return null;
            }
            public static bool ArrayContains(Array array, object contains)
            {
                return false;
            }
            public static object Clone(object obj)
            {
                return null;
            }
            public static string HtmlEscape(string str)
            {
                return null;
            }
            public static object Inherit(Function childClass, Function parentClass)
            {
                return null;
            }
            public static bool IsUndefined(object obj)
            {
                return false;
            }
        }
        
        public static double DefaultTimeoutInterval {
            [InlineCode("jasmine.DEFAULT_TIMEOUT_INTERVAL")]
            get { return 5000; }
            [InlineCode("jasmine.DEFAULT_TIMEOUT_INTERVAL = {value}")]
            set {}}

        }

    [Imported]
    public sealed class Clock
    {
        private Clock() {}

        public void Install() { }
        
        public void Uninstall() { }
        
        public void Tick(int ms) { }
    }
    [Imported]
    public interface IAny
    {
        object Any(object exportedClass);

        bool JasmineMatches(object other);
        string JasmineToString();
    }

    [Imported]
    public interface IObjectContaining
    {
        object ObjectContaining(object sample);

        bool JasmineMatches(object other, object[] mismatchKeys, object[] mismatchValues);
        string JasmineToString();
    }

    [Imported]
    public interface IBlock
    {
        object Block(Env env, SpecFunction func, Spec spec);

        void Execute(Action onComplete);
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

        public Func<Function, int, int> SetTimeout;
        public Action<int> ClearTimeout;
        public object SetInterval;
        public Action<int> ClearInterval;
        public int UpdateInterval;

        public Spec CurrentSpec;

        public Matchers MatchersClass;

        public object Version()
        {
            return null;
        }

        public string VersionString()
        {
            return null;
        }
        public int NextSpecId()
        {
            return 0;
        }
        public void AddReporter(IJsApiReporter reporter) { }
        public void Execute() { }
        public Suite Describe(string description, Action specDefinitions)
        {
            return null;
        }
        public void BeforeEach(Action beforeEachFunction){}
        public void BeforeAll(Action beforeAllFunction){}
        public IRunner CurrentRunner()
        {
            return null;
        }
        public void AfterEach(Action afterEachFunction){}
        public void AfterAll(Action afterAllFunction){}
        public IXSuite Xdescribe(string desc, Action specDefinitions)
        {
            return null;
        }
        public Spec It(string description, Action func)
        {
            return null;
        }
        public XSpec Xit(string desc, Action func)
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
        public void AddEqualityTester(Func<object, object, Env, string[], string[], bool> equalityTester) { }
        public bool SpecFilter(Spec spec)
        {
            return false;
        }
    }

    [Imported]
    public interface IFakeTimer
    {
        object FakeTimer();

        Action Reset();
        Action Tick(int millis);
        Action RunFunctionsWithinRange(int oldMillis, int nowMillis);
        Action ScheduleFunction(object timeoutKey, Action funcToCall, int millis, bool recurring);
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
        public string Type;
    }

    [Imported]
    public sealed class NestedResults : Result
    {
        private NestedResults() { }

        string _description;

        public int TotalCount;
        public int PassedCount;
        public int FailedCount;

        public bool Skipped;

        public void RollupCounts(NestedResults result) { }
        public void Log(object values) { }
        public Result[] GetItems()
        {
            return null;
        }
        public void AddResult(Result result) { }

        public bool Passed()
        {
            return false;
        }
    }

    [Imported] 
    public sealed class MessageResult : Result
    {
        private MessageResult() { }

        public object Values;
        public Trace Trace;
    }

    [Imported]
    public sealed class ExpectationResult : Result
    {
        private ExpectationResult() { }

        public string MatcherName;

        public bool Passed()
        {
            return false;
        }
        public object Expected;
        public object Actual;
        public string Message;
        public Trace Trace;
    }

    [Imported]
    public class Trace
    {
        public string Name;
        public string Message;
        public object Stack;
    }

    [Imported]
    public interface IPrettyPrinter
    {
        object PrettyPrinter();

        void Format(object value);
        void IterateObject(object obj, Action<string, bool> fn);
        void EmitScalar(object value);
        void EmitString(string value);
        void EmitArray(object[] array);
        void EmitObject(object obj);
        void Append(object value);
    }

    [Imported]
    public interface IStringPrettyPrinter : IPrettyPrinter
    {
    }

    [Imported]
    public class Queue
    {
        private Queue(object env){ }

        public Env Env;
        public bool[] Ensured;
        public IBlock[] Blocks;
        public bool Running;
        public int Index;
        public int Offset;
        public bool Abort;

        public void addBefore(IBlock block) { }
        public void addBefore(IBlock block, bool ensure) { }
        public void add(object block) { }
        public void add(object block, bool ensure) { }
        public void insertNext(object block) { }
        public void insertNext(object block, bool ensure) { }
        public void start() { }
        public void start(Action onComplete) { }
        public bool IsRunning()
        {
            return false;
        }
        public void next_() { }

        public NestedResults Results()
        {
            return null;
        }
    }

    [Imported]
    public interface IReporter
    {
        void ReportRunnerStarting(IRunner runner);
        void ReportRunnerResults(IRunner runner);
        void ReportSuiteResults(Suite suite);
        void ReportSpecStarting(Spec spec);
        void ReportSpecResults(Spec spec);
        void Log(string str);
    }

    [Imported]
    public interface IMultiReporter : IReporter
    {
        void AddReporter(IReporter reporter);
    }

    [Imported]
    public interface IRunner
    {
        object Runner(Env env);

        void Execute();
        void BeforeEach(SpecFunction beforeEachFunction);
        void AfterEach(SpecFunction afterEachFunction);
        void BeforeAll(SpecFunction beforeAllFunction);
        void AfterAll(SpecFunction afterAllFunction);
        void FinishCallback();
        void AddSuite(Suite suite);
        void Add(IBlock block);
        Spec[] Specs();
        Suite[] Suites();
        Suite[] TopLevelSuites();
        NestedResults Results();
    }
    
    public delegate void SpecFunction(Spec spec = null);

    [Imported]
    public class SuiteOrSpec
    {
        public int Id;
        public Env Env;
        public string Description;
        public Queue Queue;
    }

    [Imported]
    public class Spec : SuiteOrSpec
    {

        private Spec(Env env, Suite suite, string description) { }

        public Suite Suite;

        public SpecFunction[] AfterCallbacks;
        public Spy[] Spies;

        public NestedResults Results_;
        public Matchers MatchersClass;

        public string GetFullName()
        {
            return null;
        }
        public NestedResults Results()
        {
            return null;
        }
        public object Log(object arguments)
        {
            return null;
        }
        public Spec Runs(SpecFunction func)
        {
            return null;
        }
        public void AddToQueue(IBlock block) { }
        public void AddMatcherResult(Result result) { }
        public object Expect(object actual)
        {
            return null;
        }
        public Spec Waits(int timeout)
        {
            return null;
        }
        public Spec WaitsFor(SpecFunction latchFunction, string timeoutMessage = null, int timeout = 0)
        {
            return null;
        }
        public void fail() { }
        public void fail(object e) { }
        public Matchers getMatchersClass_()
        {
            return null;
        }
        public void AddMatchers(object matchersPrototype) { }
        public void FinishCallback() { }
        public void finish() { }
        public void finish(Action onComplete) { }
        public void After(SpecFunction doAfter) { }
        public object execute()
        {
            return null;
        }
        public object execute(Action onComplete)
        {
            return null;
        }
        public void AddBeforesAndAftersToQueue() { }
        public void Explodes() { }
        public Spy SpyOn(object obj, string methodName, bool ignoreMethodDoesntExist)
        {
            return null;
        }
        public void RemoveAllSpies() { }
    }

    [Imported]
    public class XSpec
    {
        private XSpec() { }

        public int Id;
        public void Runs() { }
    }

    [Imported]
    public class Suite : SuiteOrSpec
    {

        private Suite(Env env, string description, Action specDefinitions, Suite parentSuite) { }

        public Suite ParentSuite;

        public string GetFullName()
        {
            return null;
        }
        public void finish() { }
        public void finish(Action onComplete) { }
        public void BeforeEach(SpecFunction beforeEachFunction) { }
        public void AfterEach(SpecFunction afterEachFunction) { }
        public void BeforeAll(SpecFunction beforeAllFunction) { }
        public void AfterAll(SpecFunction afterAllFunction) { }
        public NestedResults Results()
        {
            return null;
        }
        public void Add(SuiteOrSpec suiteOrSpec) { }
        public Spec[] Specs()
        {
            return null;
        }
        public Suite[] Suites()
        {
            return null;
        }
        public object[] Children()
        {
            return null;
        }
        public void execute() { }
        public void execute(Action onComplete) { }
    }

    [Imported]
    public interface IXSuite
    {
        void Execute();
    }

    [Imported]
    public interface ISpyAnd
    {
        string Identity();
        Spy CallThrough();
        Spy ReturnValue(object val);
        Spy CallFake(Function fn);
        void ThrowError(string msg);
        Spy Stub();
    }

    [Imported]
    public interface ICalls
    {
        bool Any();
        int Count();
        object[] ArgsFor(int index);
        object[][] AllArgs();
        SpyCall[] All();
        SpyCall MostRecent();
        SpyCall First();
        void Reset();
    }

    [Imported]
    public sealed class SpyCall
    {
        private SpyCall() { }

        public object[] Args;
        public object Object;
    }

    [Imported]
    public interface IJsApiReporter
    {
        void JasmineStarted(ReporterSuiteInfo suiteInfo);
        void JasmineDone();
        void SuiteStarted(ReporterResult result);
        void SuiteDone(ReporterResult result);
        void SpecDone(ReporterResult result);
    }
    
    [Imported]
    public sealed class ReporterSuiteInfo
    {
        public int TotalSpecsDefined;
    }
    
    [Imported]
    public sealed class ReporterResult
    {
        public int Id;
        public string FullName;
        public string Description;
        public string Status;
        public ReporterError[] FailedExpectations;
    }
    
    [Imported]
    public sealed class ReporterError
    {
        public int Id;
        public string Stack;
        public string Message;
    }
}