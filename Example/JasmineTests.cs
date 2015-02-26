using System;

using System.Html;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Serialization;
using System.Threading.Tasks;
using Jasmine;

[PreserveMemberCase]
public class JasmineTests : JasmineSuite
{
    public void SpecRunner1()
    {
        /*
        describe("generic",()=>
        {
           It("assigments should work",()=>
           {
              var a=5;
              Expect(a).not.toBe(6);
           });   
        });    
        */
    }

    public void SpecRunner()
    {

        /**
         Jasmine is a behavior-driven development framework for testing JavaScript code. It does not depend on any other JavaScript frameworks. It does not require a DOM. And it has a clean, obvious syntax so that you can easily write tests.

         This guide is running against Jasmine version <span class="version">FILLED IN AT RUNTIME</span>.
         */

        /**
         ## Suites: `describe` Your Tests

         A test suite begins with a call to the global Jasmine function `describe` with two parameters: a string and a function. The string is a name or title for a spec suite - usually what is under test. The function is a block of code that implements the suite.

         ## Specs

         Specs are defined by calling the global Jasmine function `It`, which, like `describe` takes a string and a function. The string is a title for this spec and the function is the spec, or test. A spec contains one or more expectations that test the state of the code under test.

         An expectation in Jasmine is an assertion that can be either true or false. A spec with all true expectations is a passing spec. A spec with one or more expectations that evaluate to false is a failing spec.
         */
        Describe("A suite", () =>
        {
            It("contains spec with an expectation", () =>
            {
                Expect(true).ToBe(true);
            });
        });

        /**
         ### It's Just Functions

         Since `describe` and `It` blocks are functions, they can contain any executable code necessary to implement the test. JavaScript scoping rules apply, so variables declared in a `describe` are available to any `It` block inside the suite.
         */
        Describe("A suite is just a function", () =>
        {
            bool a;

            It("and so is a spec", () =>
            {
                a = true;

                Expect(a).ToBe(true);
            });
        });

        /**
         ## Expectations

         Expectations are built with the function `Expect` which takes a value, called the actual. It is chained with a Matcher function, which takes the expected value.
         */
        Describe("The 'toBe' matcher compares with ===", () =>
        {
            /**
             ### Matchers

             Each matcher implements a boolean comparison between the actual value and the expected value. It is responsible for reporting to Jasmine if the expectation is true or false. Jasmine will then pass or fail the spec.
             */

            It("and has a positive case ", () =>
            {
                Expect(true).ToBe(true);
            });

            /**
             Any matcher can evaluate to a negative assertion by chaining the call to `Expect` with a `not` before calling the matcher.

             */

            It("and can have a negative case", () =>
            {
                Expect(false).Not.ToBe(true);
            });
        });

        /**
         ### Included Matchers

         Jasmine has a rich set of matchers included. Each is used here - all expectations and specs pass.

         There is also the ability to write [custom matchers](https://github.com/pivotal/jasmine/wiki/Matchers) for when a project's domain calls for specific assertions that are not included below.
         */

        Describe("Included matchers:", () =>
        {

            It("The 'toBe' matcher compares with ===", () =>
            {
                int a = 12;
                int b = a;

                Expect(a).ToBe(b);
                Expect(a).Not.ToBe(null);
            });

            Describe("The 'toEqual' matcher", () =>
            {

                It("works for simple literals and variables", () =>
                {
                    int a = 12;
                    Expect(a).ToEqual(12);
                });

                It("should work for objects", () =>
                {
                    JsDictionary<string, int> foo = new JsDictionary<string, int>();
                    JsDictionary<string, int> bar = new JsDictionary<string, int>();
                    foo["a"] = 12;
                    foo["b"] = 34;
                    bar["a"] = 12;
                    bar["b"] = 34;
                    Expect(foo).ToEqual(bar);
                });
            });

            It("The 'toMatch' matcher is for regular expressions", () =>
            {
                string message = "foo bar baz";

                //Expect(message).toMatch(/bar/);       // regex literal expressions do not exist in C#
                Expect(message).ToMatch("bar");
                //Expect(message).not.toMatch(/quux/);  // regex literal expressions do not exist in C#
            });

            It("The 'toBeDefined' matcher compares against `undefined`", () =>
            {
                JsDictionary<string, string> a = new JsDictionary<string, string>();
                a["foo"] = "foo";

                Expect(a["foo"]).ToBeDefined();
                Expect((object)((dynamic)a).bar).Not.ToBeDefined();    // dynamic so that you can call a.bar from C#
            });

            It("The `toBeUndefined` matcher compares against `undefined`", () =>
            {
                JsDictionary<string, string> a = new JsDictionary<string, string>();
                a["foo"] = "foo";

                Expect(a["foo"]).Not.ToBeUndefined();
                Expect((object)((dynamic)a).bar).ToBeUndefined();
            });

            It("The 'toBeNull' matcher compares against null", () =>
            {
                string a = null;
                string foo = "foo";

                Expect(null).ToBeNull();
                Expect(a).ToBeNull();
                Expect(foo).Not.ToBeNull();
            });

            It("The 'toBeTruthy' matcher is for boolean casting testing", () =>
            {
                string a = null;
                string foo = "foo";

                Expect(foo).ToBeTruthy();
                Expect(a).Not.ToBeTruthy();
            });

            It("The 'toBeFalsy' matcher is for boolean casting testing", () =>
            {
                string a = null;
                string foo = "foo";

                Expect(a).ToBeFalsy();
                Expect(foo).Not.ToBeFalsy();
            });

            It("The 'toContain' matcher is for finding an item in an Array", () =>
            {
                string[] a = new string[] { "foo", "bar", "baz" };

                Expect(a).ToContain("bar");
                Expect(a).Not.ToContain("quux");
            });

            It("The 'toBeLessThan' matcher is for mathematical comparisons", () =>
            {
                double pi = 3.1415926;
                double e = 2.78;

                Expect(e).ToBeLessThan(pi);
                Expect(pi).Not.ToBeLessThan(e);
            });

            It("The 'toBeGreaterThan' is for mathematical comparisons", () =>
            {
                double pi = 3.1415926;
                double e = 2.78;

                Expect(pi).ToBeGreaterThan(e);
                Expect(e).Not.ToBeGreaterThan(pi);
            });

            It("The 'toBeCloseTo' matcher is for precision math comparison", () =>
            {
                double pi = 3.1415926;
                double e = 2.78;

                Expect(pi).Not.ToBeCloseTo(e, 2);
                Expect(pi).ToBeCloseTo(e, 0);
            });

            It("The 'toThrow' matcher is for testing if a function throws an exception", () =>
            {
                Func<int> foo = () =>
                {
                    return 1 + 2;
                };
                Func<int> bar = () =>
                {
                    throw new Exception("err!");
                    return 1 + 1;
                };

                Expect(foo).Not.ToThrow();
                Expect(bar).ToThrow();
            });
        });

        /**
         ## Grouping Related Specs with `describe`

         The `describe` function is for grouping related specs. The string parameter is for naming the collection of specs, and will be concatenated with specs to make a spec's full name. This aids in finding specs in a large suite. If you name them well, your specs read as full sentences in traditional [BDD][bdd] style.

         [bdd]: http://en.wikipedia.org/wiki/Behavior-driven_development
         */
        Describe("A spec", () =>
        {
            It("is just a function, so It can contain any code", () =>
            {
                int foo = 0;
                foo += 1;

                Expect(foo).ToEqual(1);
            });

            It("can have more than one expectation", () =>
            {
                int foo = 0;
                foo += 1;

                Expect(foo).ToEqual(1);
                Expect(true).ToEqual(true);
            });
        });

        /**
         ### Setup and Teardown

         To help a test suite DRY up any duplicated setup and teardown code, Jasmine provides the global `BeforeEach` and `AfterEach` functions. As the name implies the `BeforeEach` function is called once before each spec in the `describe` is run and the `AfterEach` function is called once after each spec.

         Here is the same set of specs written a little differently. The variable under test is defined at the top-level scope -- the `describe` block --  and initialization code is moved into a `BeforeEach` function. The `AfterEach` function resets the variable before continuing.

         */

        Describe("A spec (with setup and tear-down)", () =>
        {
            int foo = 0;

            BeforeEach(() =>
            {
                foo = 0;
                foo += 1;
            });

            AfterEach(() =>
            {
                foo = 0;
            });

            It("is just a function, so It can contain any code", () =>
            {
                Expect(foo).ToEqual(1);
            });

            It("can have more than one expectation", () =>
            {
                Expect(foo).ToEqual(1);
                Expect(true).ToEqual(true);
            });
        });

        /**
         ### Nesting `describe` Blocks

         Calls to `describe` can be nested, with specs defined at any level. This allows a suite to be composed as a tree of functions. Before a spec is executed, Jasmine walks down the tree executing each `BeforeEach` function in order. After the spec is executed, Jasmine walks through the `AfterEach` functions similarly.

         */
        Describe("A spec", () =>
        {
            int foo = 0;

            BeforeEach(() =>
            {
                foo = 0;
                foo += 1;
            });

            AfterEach(() =>
            {
                foo = 0;
            });

            It("is just a function, so It can contain any code", () =>
            {
                Expect(foo).ToEqual(1);
            });

            It("can have more than one expectation", () =>
            {
                Expect(foo).ToEqual(1);
                Expect(true).ToEqual(true);
            });

            Describe("nested inside a second describe", () =>
            {
                int bar = 0;

                BeforeEach(() =>
                {
                    bar = 1;
                });

                It("can reference both scopes as needed ", () =>
                {
                    Expect(foo).ToEqual(bar);
                });
            });
        });

        /**
         ## Disabling Specs and Suites

         Suites and specs can be disabled with the `xdescribe` and `xit` functions, respectively. These suites and specs are skipped when run and thus their results will not appear in the results.

         */
        XDescribe("A spec", () =>
        {
            int foo = 0;

            BeforeEach(() =>
            {
                foo = 0;
                foo += 1;
            });

            XIt("is just a function, so It can contain any code", () =>
            {
                Expect(foo).ToEqual(1);
            });
        });

        /**
        ## Pending Specs
        Pending specs do not run, but their names will show up in the results as `pending`.
        */
        //TODO: Pending() doesn't work in PhantomJS
        //describe("Pending specs", () =>
        //{

        //    /** Any spec declared with `xit` is marked as pending.
        //     */
        //    xit("can be declared 'xit'", () =>
        //    {
        //        Expect(true).toBe(false);
        //    });

        //    /** Any spec declared without a function body will also be marked pending in results.
        //     */

        //    It("can be declared with 'It' but without a function");

        //    /** And if you call the function `pending` anywhere in the spec body, no matter the expectations, the spec will be marked pending.
        //     */
        //    It("can be declared by calling 'pending' in the spec body", () =>
        //    {
        //        Expect(true).toBe(false);
        //        pending();
        //    });
        //});

        /**
         ## Spies

         Jasmine's test doubles are called spies. A spy can stub any function and tracks calls to It and all arguments. There are special matchers for interacting with spies.

         The `toHaveBeenCalled` matcher will return true if the spy was called. The `toHaveBeenCalledWith` matcher will return true if the argument list matches any of the recorded calls to the spy.
         */

        // TODO object containing a function
        Describe("A spy", () =>
        {
            JsDictionary<string, Action<string>> foo = new JsDictionary<string, Action<string>>();
            foo["setBar"] = null;
            string bar = null;
            Spy spy = null;

            BeforeEach(() =>
            {

                foo["setBar"] = (value) =>
                {
                    bar = value;
                };

                spy = SpyOn(foo, "setBar");

                foo["setBar"]("123");
                foo["setBar"]("456");
            });

            It("tracks that the spy was called", () =>
            {
                Expect(foo["setBar"]).ToHaveBeenCalled();
            });

            It("tracks its number of calls", () =>
            {
                Expect(spy.Calls.Count()).ToEqual(2);
            });

            It("tracks all the arguments of its calls", () =>
            {
                Expect(spy).ToHaveBeenCalledWith("123");
            });

            It("allows access to the most recent call", () =>
            {
                Expect(spy.Calls.MostRecent().Args[0]).ToEqual("456");
            });

            It("allows access to other calls", () =>
            {
                Expect(spy.Calls.All()[0].Args[0]).ToEqual("123");
            });

            It("stops all execution on a function", () =>
            {
                Expect(bar).ToBeNull();
            });
        });


        /**
         ### Spies: `and.callThrough`

         By chaining the spy with `and.callThrough`, the spy will still track all calls to It but in addition It will delegate to the actual implementation.
         */

        // TODO object containing a function
        Describe("A spy, when configured to call through", () =>
        {
            JsDictionary foo = new JsDictionary();
            foo["setBar"] = null;
            foo["getBar"] = null;
            string bar = null;
            string fetchedBar = null;
            Spy spy = null;

            BeforeEach(() =>
            {
                foo["setBar"] = new Action<string>((value) =>
                {
                    bar = value;
                });
                foo["getBar"] = new Func<string>(() => bar);

                spy = SpyOn(foo, "getBar").And.CallThrough();

                ((Action<string>)foo["setBar"])("123");
                fetchedBar = ((Func<string>)foo["getBar"])();
            });

            It("tracks that the spy was called", () =>
            {
                Expect(spy).ToHaveBeenCalled();
            });

            It("should not effect other functions", () =>
            {
                Expect(bar).ToEqual("123");
            });

            It("when called returns the requested value", () =>
            {
                Expect(fetchedBar).ToEqual("123");
            });
        });


        /**
         ### Spies: `and.returnValue`

         By chaining the spy with `and.returnValue`, all calls to the function will return a specific value.
         */
        // TODO object containing a function
        Describe("A spy, when faking a return value", () =>
        {
            JsDictionary foo = new JsDictionary();
            foo["setBar"] = null;
            foo["getBar"] = null;
            string bar = null;
            string fetchedBar = null;
            Spy spy = null;

            BeforeEach(() =>
            {
                foo["setBar"] = new Action<string>((value) =>
                {
                    bar = value;
                });
                foo["getBar"] = new Func<string>(() => bar);

                spy = SpyOn(foo, "getBar").And.ReturnValue("745");

                ((Action<string>)foo["setBar"])("123");
                fetchedBar = ((Func<string>)foo["getBar"])();
            });

            It("tracks that the spy was called", () =>
            {
                Expect(spy).ToHaveBeenCalled();
            });

            It("should not effect other functions", () =>
            {
                Expect(bar).ToEqual("123");
            });

            It("when called returns the requested value", () =>
            {
                Expect(fetchedBar).ToEqual("745");
            });
        });


        /**
         ### Spies: `and.callFake`

         By chaining the spy with `and.callFake`, all calls to the spy will delegate to the supplied function.
         */
        // TODO objects containing functions
        Describe("A spy, when faking a function", () =>
        {
            JsDictionary foo = new JsDictionary();
            foo["setBar"] = null;
            foo["getBar"] = null;
            string bar = null;
            string fetchedBar = null;
            Spy spy = null;

            BeforeEach(() =>
            {

                foo["setBar"] = new Action<string>((value) =>
                {
                    bar = value;
                });
                foo["getBar"] = new Func<string>(() => bar);

                spy = SpyOn(foo, "getBar").And.CallFake((Function)(new Func<string>(() => "1001")));

                ((Action<string>)foo["setBar"])("123");
                fetchedBar = ((Func<string>)foo["getBar"])();
            });

            It("tracks that the spy was called", () =>
            {
                Expect(spy).ToHaveBeenCalled();
            });

            It("should not effect other functions", () =>
            {
                Expect(bar).ToEqual("123");
            });

            It("when called returns the requested value", () =>
            {
                Expect(fetchedBar).ToEqual("1001");
            });
        });

        /**
        ### Spies: `and.throwError`
        By chaining the spy with `and.throwError`, all calls to the spy will `throw` the specified value as an error.
        */
        Describe("A spy, when configured to throw an error", () =>
        {
            JsDictionary<string, Action<string>> foo = new JsDictionary<string, Action<string>>();
            foo["setBar"] = null;
            string bar = null;

            BeforeEach(() =>
            {
                foo["setBar"] = (value) =>
                {
                    bar = value;
                };

                SpyOn(foo, "setBar").And.ThrowError("quux");
            });

            It("throws the value", () =>
            {
                Expect(new Action(() =>
                {
                    foo["setBar"]("123");
                })).toThrowError("quux");
            });
        });


        /**
        ### Spies: `and.stub`
        When a calling strategy is used for a spy, the original stubbing behavior can be returned at any time with `and.stub`.
        */
        Describe("A spy", () =>
        {
            JsDictionary<string, Action<double?>> foo = new JsDictionary<string, Action<double?>>();
            foo["setBar"] = null;
            double? bar = null;
            Spy spy = null;

            BeforeEach(() =>
            {
                foo["setBar"] = (value) =>
                {
                    bar = value;
                };

                spy = SpyOn(foo, "setBar").And.CallThrough();
            });

            It("can call through and then stub in the same spec", () =>
            {
                foo["setBar"](123);
                Expect(bar).ToEqual(123);

                spy.And.Stub();
                bar = null;

                foo["setBar"](123);
                Expect(bar).ToBe(null);
            });
        });

        /**
        ### Other tracking properties

        Every call to a spy is tracked and exposed on the `calls` property.
        */
        Describe("A spy", () =>
        {

            JsDictionary<string, Action<double?>> foo = new JsDictionary<string, Action<double?>>();
            foo["setBar"] = null;
            double? bar = null;
            Spy fooSetBar = null;

            BeforeEach(() =>
            {
                foo["setBar"] = (value) =>
                {
                    bar = value;
                };

                fooSetBar = SpyOn(foo, "setBar");
            });

            /**
             * `.calls.any()`: returns `false` if the spy has not been called at all, and then `true` once at least one call happens.
             */
            It("tracks if It was called at all", () =>
            {
                Expect(fooSetBar.Calls.Any()).ToEqual(false);

                foo["setBar"](0);

                Expect(fooSetBar.Calls.Any()).ToEqual(true);
            });

            /**
             * `.calls.count()`: returns the number of times the spy was called
             */
            It("tracks the number of times It was called", () =>
            {
                Expect(fooSetBar.Calls.Count()).ToEqual(0);

                foo["setBar"](0);
                foo["setBar"](0);

                Expect(fooSetBar.Calls.Count()).ToEqual(2);
            });

            /**
             * `.calls.argsFor(index)`: returns the arguments passed to call number `index`
             */
            It("tracks the arguments of each call", () =>
            {
                foo["setBar"](123);
                foo["setBar"](456);

                Expect(fooSetBar.Calls.ArgsFor(0)).ToEqual(new[] { 123 });
                Expect(fooSetBar.Calls.ArgsFor(1)).ToEqual(new[] { 456 });
            });

            /**
             * `.calls.allArgs()`: returns the arguments to all calls
             */
            It("tracks the arguments of all calls", () =>
            {
                foo["setBar"](123);
                foo["setBar"](456);

                Expect(fooSetBar.Calls.AllArgs()).ToEqual(new[] { new[] { 123 }, new[] { 456 } });
            });

            /**
             * `.calls.all()`: returns the context (the `this`) and arguments passed all calls
             */
            It("can provide the context and arguments to all calls", () =>
            {
                foo["setBar"](123);

                Expect(fooSetBar.Calls.All()).ToEqual(new[] { new { @object = foo, args = new[] { 123 }, returnValue = Script.Undefined } });
            });

            /**
             * `.calls.mostRecent()`: returns the context (the `this`) and arguments for the most recent call
             */
            It("has a shortcut to the most recent call", () =>
            {
                foo["setBar"](123);
                foo["setBar"](456);

                Expect(fooSetBar.Calls.MostRecent()).ToEqual(new { @object = foo, args = new[] { 456 }, returnValue = Script.Undefined });
            });

            /**
             * `.calls.first()`: returns the context (the `this`) and arguments for the first call
             */
            It("has a shortcut to the first call", () =>
            {
                foo["setBar"](123);
                foo["setBar"](456);

                Expect(fooSetBar.Calls.First()).ToEqual(new { @object = foo, args = new[] { 123 }, returnValue = Script.Undefined });
            });

            /**
             * When inspecting the return from `all()`, `mostRecent()` and `first()`, the `object` property is set to the value of `this` when the spy was called.
             */
            It("tracks the context", () =>
            {
                Spy spy = CreateSpy("spy");

                JsDictionary<string, Spy> baz = new JsDictionary<string, Spy>();
                JsDictionary<string, Spy> quux = new JsDictionary<string, Spy>();

                baz["fn"] = spy;
                quux["fn"] = spy;
                baz["fn"].Call(123);
                quux["fn"].Call(456);

                Expect(spy.Calls.First().Object).ToBe(baz);
                Expect(spy.Calls.MostRecent().Object).ToBe(quux);
            });

            /**
             * `.calls.reset()`: clears all tracking for a spy
             */
            It("can be reset", () =>
            {
                foo["setBar"](123);
                foo["setBar"](456);

                Expect(fooSetBar.Calls.Any()).ToBe(true);

                fooSetBar.Calls.Reset();

                Expect(fooSetBar.Calls.Any()).ToBe(false);
            });
        });

        /**
         ### Spies: `CreateSpy`

         When there is not a function to spy on, `jasmine.CreateSpy` can create a "bare" spy. This spy acts as any other spy - tracking calls, arguments, etc. But there is no implementation behind It. Spies are JavaScript objects and can be used as such.

         */
        Describe("A spy, when created manually", () =>
        {
            Spy whatAmI = null;

            BeforeEach(() =>
            {
                whatAmI = CreateSpy("whatAmI");

                whatAmI.Call("I", "am", "a", "spy");
            });

            It("is named, which helps in error reporting", () =>
            {
                Expect(whatAmI.And.Identity()).ToEqual("whatAmI");
            });

            It("tracks that the spy was called", () =>
            {
                Expect(whatAmI).ToHaveBeenCalled();
            });

            It("tracks its number of calls", () =>
            {
                Expect(whatAmI.Calls.Count()).ToEqual(1);
            });

            It("tracks all the arguments of its calls", () =>
            {
                Expect(whatAmI).ToHaveBeenCalledWith("I", "am", "a", "spy");
            });

            It("allows access to the most recent call", () =>
            {
                Expect(whatAmI.Calls.MostRecent().Args[0]).ToEqual("I");
            });
        });

        /**
         ### Spies: `createSpyObj`

         In order to create a mock with multiple spies, use `jasmine.createSpyObj` and pass an array of strings. It returns an object that has a property for each string that is a spy.
         */
        Describe("Multiple spies, when created manually", () =>
        {
            dynamic tape = null;

            BeforeEach(() =>
            {
                tape = CreateSpyObj("tape", new string[] { "play", "pause", "stop", "rewind" });

                tape.play();
                tape.pause();
                tape.rewind(0);
            });

            It("creates spies for each requested function", () =>
            {
                Expect((object)tape.play).ToBeDefined();
                Expect((object)tape.pause).ToBeDefined();
                Expect((object)tape.stop).ToBeDefined();
                Expect((object)tape.rewind).ToBeDefined();
            });

            It("tracks that the spies were called", () =>
            {
                Expect((object)tape.play).ToHaveBeenCalled();
                Expect((object)tape.pause).ToHaveBeenCalled();
                Expect((object)tape.rewind).ToHaveBeenCalled();
                Expect((object)tape.stop).Not.ToHaveBeenCalled();
            });

            It("tracks all the arguments of its calls", () =>
            {
                Expect((object)tape.rewind).ToHaveBeenCalledWith(0);
            });
        });

        /**
         ## Matching Anything with `jasmine.any`

         `jasmine.any` takes a constructor or "class" name as an expected value. It returns `true` if the constructor matches the constructor of the actual value.
         */

        // TODO any matcher
        Describe("jasmine.any", () =>
        {
            It("matches any value", () =>
            {
                Expect(null).ToEqual(Any(typeof(Object)));
                Expect(12).ToEqual(Any(typeof(Double)));
            });

            Describe("when used with a spy", () =>
            {
                It("is useful for comparing arguments", () =>
                {
                    Spy foo = CreateSpy("foo");
                    foo.Call(12, new Func<bool>(() => true));

                    Expect(foo).ToHaveBeenCalledWith(Any(typeof(Double)), Any(typeof(Function)));
                });
            });
        });

        /**
         ## Partial Matching with `jasmine.objectContaining`
         `jasmine.objectContaining` is for those times when an expectation only cares about certain key/value pairs in the actual.
         */

        Describe("jasmine.objectContaining", () =>
        {
            JsDictionary foo = new JsDictionary();

            foo["a"] = 0;
            foo["b"] = 0;
            foo["bar"] = "";

            BeforeEach(() =>
            {

                foo["a"] = 1;
                foo["b"] = 2;
                foo["bar"] = "baz";
            });

            It("matches objects with the Expect key/value pairs", () =>
            {
                Expect(foo).ToEqual(ObjectContaining(new
                {
                    bar = "baz"
                }));
                Expect(foo).Not.ToEqual(ObjectContaining(new
                {
                    c = 37
                }));
            });

            Describe("when used with a spy", () =>
            {
                It("is useful for comparing arguments", () =>
                {
                    Spy callback = CreateSpy("callback");

                    callback.Call(new
                    {
                        bar = "baz"
                    });

                    Expect(callback).ToHaveBeenCalledWith(ObjectContaining(new
                    {
                        bar = "baz"
                    }));
                    Expect(callback).Not.ToHaveBeenCalledWith(ObjectContaining(new
                    {
                        c = 37
                    }));
                });
            });
        });


        /**
         ## Mocking the JavaScript Clock

         The Jasmine Mock Clock is available for a test suites that need the ability to use `setTimeout` or `setInterval` callbacks. It makes the timer callbacks synchronous, thus making them easier to test.

         */
        // TODO clock
        Describe("Manually ticking the Jasmine Mock Clock", () =>
        {
            Spy timerCallback = null;

            //
            // It is installed with a call to `jasmine.Clock.useMock` in a spec or suite that needs to call the timer functions.
            //
            BeforeEach(() =>
            {
                timerCallback = CreateSpy("timerCallback");
                Clock().Install();
            });

            AfterEach(() =>
            {
                timerCallback = CreateSpy("timerCallback");
                Clock().Uninstall();
            });

            //
            // Calls to any registered callback are triggered when the clock is ticked forward via the `jasmine.Clock.tick` function, which takes a number of milliseconds.
            //
            It("causes a timeout to be called synchronously", () =>
            {
                Window.SetTimeout(() =>
                {
                    timerCallback.Call();
                }, 100);



                Expect(timerCallback).Not.ToHaveBeenCalled();

                Clock().Tick(101);

                Expect(timerCallback).ToHaveBeenCalled();
            });

            It("causes an interval to be called synchronously", () =>
            {
                Window.SetInterval(() =>
                {
                    timerCallback.Call();
                }, 100);

                Expect(timerCallback).Not.ToHaveBeenCalled();

                Clock().Tick(101);
                Expect(timerCallback.Calls.Count()).ToEqual(1);

                Clock().Tick(50);
                Expect(timerCallback.Calls.Count()).ToEqual(1);

                Clock().Tick(50);
                Expect(timerCallback.Calls.Count()).ToEqual(2);
            });
        });


        /**
         ## Asynchronous Support
         __This syntax has changed for Jasmine 2.0.__
         Jasmine also has support for running specs that require testing asynchronous operations.
         */
        Describe("Asynchronous specs", () =>
        {
            double value = 0;
            /**
             Calls to `BeforeEach`, `It`, and `AfterEach` can take an optional single argument that should be called when the async work is complete.
             */
            BeforeEach((done) =>
            {
                Window.SetTimeout(() =>
                {
                    value = 0;
                    done();
                }, 1000);
            });

            /**
             This spec will not start until the `done` function is called in the call to `BeforeEach` above. And this spec will not complete until its `done` is called.
             */

            It("should support async execution of test preparation and expectations", (done) =>
            {
                value++;
                Expect(value).ToBeGreaterThan(0);


                Task.Delay(1).ContinueWith((T) =>
                {
                    value = 1;
                    Expect(value).ToBeGreaterThan(0);
                    done();
                });
            });

            /**
             By default jasmine will wait for 5 seconds for an asynchronous spec to finish before causing a timeout failure.
             If specific specs should fail faster or need more time this can be adjusted by setting `jasmine.DEFAULT_TIMEOUT_INTERVAL` around them.

             If the entire suite should have a different timeout, `jasmine.DEFAULT_TIMEOUT_INTERVAL` can be set globally, outside of any given `describe`.
             */
            Describe("long asynchronous specs", () =>
            {
                double originalTimeout = 0;
                BeforeEach(() =>
                {
                    originalTimeout = DefaultTimeoutInterval;
                    DefaultTimeoutInterval = 1000;
                });

                It("takes a long time", (done) =>
                {
                    Window.SetTimeout(() =>
                    {
                        done();
                    }, 900);
                });

                AfterEach(() =>
                {
                    DefaultTimeoutInterval = originalTimeout;
                });
            });
        });


        /**
         *
         * Often a project will want to encapsulate custom matching code for use across multiple specs. Here is how to create a Jasmine-compatible custom matcher.
         *
         * A custom matcher at its root is a comparison function that takes an `actual` value and `expected` value. This factory is passed to Jasmine, ideally in a call to `BeforeEach` and will be in scope and available for all of the specs inside a given call to `describe`. Custom matchers are torn down between specs. The name of the factory will be the name of the matcher exposed on the return value of the call to `Expect`.
         *
         */

        /**
        * ## Matcher Factories
        *
        * Custom matcher factories are passed two parameters: `util`, which has a set of utility functions for matchers to use (see: [`matchersUtil.js`][mu.js] for the current list) and `customEqualityTesters` which needs to be passed in if `util.equals` is ever called. These parameters are available for use when then matcher is called.
        *
        * [mu.js]: https://github.com/pivotal/jasmine/blob/master/src/core/matchers/matchersUtil.js
        */
        /**
        * The factory method should return an object with a `compare` function that will be called to check the expectation.
        */
        var customMatchers = new JsDictionary<string, CustomMatcherComparer>();
        customMatchers["toBeGoofy"] = _toBeGoofy;
        customMatchers["toBeDivisibleBy"] = _toBeDivisibleBy;


        /**
        * ### Custom negative comparators
        *
        * If you need more control over the negative comparison (the `not` case) than the simple boolean inversion above, you can also have your matcher factory include another key, `negativeCompare` alongside `compare`, for which the value is a function to invoke when `.not` is used. This function/key is optional.
        */

        /**
         * ## Registration and Usage
         */
        Describe("Custom matcher: 'toBeGoofy'", () =>
        {
            /**
             * Register the custom matchers with Jasmine. All properties on the object passed in will be available as custom matchers (e.g., in this case `toBeGoofy`).
             */
            BeforeEach(() =>
            {
                //AddMatchers(customMatchers);
                AddMatcher("toBeGoofy", _toBeGoofy);
            });

            /**
             * Once a custom matcher is registered with Jasmine, It is available on any expectation.
             */
            It("is available on an expectation", () =>
            {
                Expect(new
                {
                    hyuk = "gawrsh"
                }).ToBeGoofy();
            });

            It("can take an 'expected' parameter", () =>
            {
                Expect(new
                {
                    hyuk = "gawrsh is fun"
                }).ToBeGoofy(" is fun");
            });

            It("can be negated", () =>
            {
                Expect(new
                {
                    hyuk = "this is fun"
                }).Not.ToBeGoofy();
            });
        });

        Describe("Custom matcher: 'toBeDivisibleBy'", () =>
        {
            BeforeEach(() =>
            {
                AddMatchers(customMatchers);
            });

            It("is available on an expectation", () =>
            {
                Expect(7).ToBeDivisibleBy(7);
            });

            It("can be negated", () =>
            {
                Expect(8).Not.ToBeDivisibleBy(7);
            });
        });

        /**
        * ## Custom Equality Testers
        */
        Describe("custom equality", () =>
        {
            /**
             * You can customize how jasmine determines if two objects are equal by defining your own custom equality testers.
             * A custom equality tester is a function that takes two arguments.
             */
            Func<string, string, bool> myCustomEquality = (first, second) =>
            {
                /**
                 * If the custom equality tester knows how to compare the two items, It should return either true or false
                 */

                if (Script.TypeOf(first) == "string" && Script.TypeOf(second) == "string")
                {
                    return first[0] == second[1];
                }

                return false;

                /**
                 * Otherwise, It should return undefined, to tell jasmine's equality tester that It can't compare the items
                 */
            };

            /**
             * Then you register your tester in a `BeforeEach` so jasmine knows about It.
             */
            BeforeEach(() =>
            {
                AddCustomEqualityTester(myCustomEquality);
            });

            /**
             * Then when you do comparisons in a spec, custom equality testers will be checked first before the default equality logic.
             */
            It("should be custom equal", () =>
            {
                Expect("abc").ToEqual("aaa");
            });

            /**
             * If your custom tester returns false, no other equality checking will be done.
             */
            It("should be custom not equal", () =>
            {
                Expect("abc").Not.ToEqual("abc");
            });
        });

        /**
         *
         * If you don't like the way the built-in jasmine reporters look, you can always write your own.
         *
         */

        /**
         * A jasmine reporter is just an object with the right functions available.
         * None of the functions here are required when creating a custom reporter, any that are not specified on your reporter will just be ignored.
         */

        IJsApiReporter myReporter = new NewReporter();

        /**
            * Register the reporter with jasmine
            */
        GetEnv().AddReporter(myReporter);

        /**
         * If you look at the console output for this page, you should see the output from this reporter
         */
        Describe("Top Level suite", () =>
        {
            It("spec", () =>
            {
                Expect(1).ToBe(1);
            });

            Describe("Nested suite", () =>
            {
                It("nested spec", () =>
                {
                    Expect(true).ToBe(true);
                });
            });
        });

        /**
         Focusing specs will make It so that they are the only specs that run.
         */

        //describe("Focused specs", () => {

        //    /** Any spec declared with `fit` is focused.
        //     */
        //    fit("is focused and will run", () => {
        //        Expect(true).toBeTruthy();
        //    });

        //    It("is not focused and will not run", () =>{
        //        Expect(true).toBeFalsy();
        //    });

        //    /** You can focus on a `describe` with `fdescribe`
        //     *
        //     */
        //    fdescribe("focused describe", () =>{
        //        It("will run", () =>{
        //            Expect(true).toBeTruthy();
        //        });

        //        It("will also run", () =>{
        //            Expect(true).toBeTruthy();
        //        });
        //    });

        //    /** If you nest focused and unfocused specs inside `fdescribes`, only focused specs run.
        //     *
        //     */
        //    fdescribe("another focused describe", () =>{
        //        fit("is focused and will run", () => {
        //            Expect(true).toBeTruthy();
        //        });

        //        It("is not focused and will not run", () =>{
        //            Expect(true).toBeFalsy();
        //        });
        //    });
        //});

    }

    private readonly static CustomMatcherComparer _toBeGoofy =
        (util, customEqualityTesters, actual, expected) =>
        {
            /**
             * `toBeGoofy` takes an optional `expected` argument, so define It here if not passed in.
             */
            if (expected == null)
                expected = "";

            /**
             * ### Result
             *
             * The `compare` function must return a result object with a `pass` property that is a boolean result of the matcher. The `pass` property tells the expectation whether the matcher was successful (`true`) or unsuccessful (`false`). If the expectation is called/chained with `.not`, the expectation will negate this to determine whether the expectation is met.
             */
            /**
             * `toBeGoofy` tests for equality of the actual's `hyuk` property to see if It matches the expectation.
             */
            bool resultPass = util.Equals(((JsDictionary)actual)["hyuk"], "gawrsh" + expected, customEqualityTesters);

            /**
             * ### Failure Messages
             *
             * If left `undefined`, the expectation will attempt to craft a failure message for the matcher. However, if the return value has a `message` property It will be used for a  failed expectation.
             */
            string resultMessage = string.Format(resultPass ? "Expected {0} not to be quite so goofy" : "Expected {0} to be goofy, but It was not very goofy", actual);

            /**
             * Return the result of the comparison.
             */
            return new MatcherResult(resultPass, resultMessage);
        };


    private static readonly CustomMatcherComparer _toBeDivisibleBy =
        (util, customEqualityTesters, actual, expected) =>
    {
        bool ResultPass = false;
        string ResultMessage = "";
        var MatcherResult = new MatcherResult(ResultPass, ResultMessage);

        int? actualConvert = actual as int?;
        if (actualConvert != null)
            MatcherResult.Pass = actualConvert.Value%(int) expected == 0;
        else
        {
            MatcherResult.Message = string.Format("Expected {0} to be divisble by {1}, but It was not a number", actual,
                expected);
            return MatcherResult;
        }

        MatcherResult.Message = string.Format(MatcherResult.Pass ? "Expected {0} not to be divisble by {1}" : "Expected {0} to be divisble by {1}", actual, expected);

        return MatcherResult;
    };

    public class MatcherResult : IMatcherResult
    {
        public bool Pass;
        public string Message;

        public MatcherResult(bool pass, string message)
        {
            Pass = pass;
            Message = message;
        }
    }
}

public static class MatcherExtensions
{
    [InstanceMethodOnFirstArgument]
    public static bool ToBeGoofy(this Matchers matcher)
    {
        return false;
    }

    [InstanceMethodOnFirstArgument]
    public static bool ToBeGoofy(this Matchers matcher, string expected)
    {
        return false;
    }

    [InstanceMethodOnFirstArgument]
    public static bool ToBeDivisibleBy(this Matchers matcher, int expected)
    {
        return false;
    }
}

public class NewReporter : IJsApiReporter
{
    /**
             * ### jasmineStarted
             *
             * `jasmineStarted` is called after all of the specs have been loaded, but just before execution starts.
             */
    public void JasmineStarted(ReporterSuiteInfo suiteInfo)
    {
        /**
         * suiteInfo contains a property that tells how many specs have been defined
         */
        Console.WriteLine("Running suite with " + suiteInfo.TotalSpecsDefined);
    }
    /**
     * ### suiteStarted
     *
     * `suiteStarted` is invoked when a `describe` starts to run
     */
    public void SuiteStarted(ReporterResult result)
    {
        /**
         * the result contains some meta data about the suite itself.
         */
        Console.WriteLine("Suite started: " + result.Description + " whose full description is: " + result.FullName);
    }
    /**
    * ### specStarted
    *
    * `specStarted` is invoked when an `It` starts to run (including associated `BeforeEach` functions)
    */
    public void SpecStarted(ReporterResult result)
    {
        /**
            * the result contains some meta data about the spec itself.
            */
        Console.WriteLine("Spec started: " + result.Description + " whose full description is: " + result.FullName);
    }
    /**
    * ### specDone
    *
    * `specDone` is invoked when an `It` and its associated `BeforeEach` and `AfterEach` functions have been run.
    *
    * While jasmine doesn't require any specific functions, not defining a `specDone` will make It impossible for a reporter to know when a spec has failed.
    */
    public void SpecDone(ReporterResult result)
    {
        /**
            * The result here is the same object as in `specStarted` but with the addition of a status and a list of failedExpectations.
            */
        Console.WriteLine("Spec: " + result.Description + " was " + result.Status);
        for (var i = 0; i < result.FailedExpectations.Length; i++)
        {
            /**
            * Each `failedExpectation` has a message that describes the failure and a stack trace.
            */
            Console.WriteLine("Failure: " + result.FailedExpectations[i].Message);
            Console.WriteLine(result.FailedExpectations[i].Stack);
        }
    }
    /**
    * ### suiteDone
    *
    * `suiteDone` is invoked when all of the child specs and suites for a given suite have been run
    *
    * While jasmine doesn"t require any specific functions, not defining a `suiteDone` will make It impossible for a reporter to know when a suite has failures in an `afterAll`.
    */
    public void SuiteDone(ReporterResult result)
    {
        /**
        * The result here is the same object as in `suiteStarted` but with the addition of a status and a list of failedExpectations.
        */
        Console.WriteLine("Suite: " + result.Description + " was " + result.Status);
        for (var i = 0; i < result.FailedExpectations.Length; i++)
        {
            /**
            * Any `failedExpectation`s on the suite itself are the result of a failure in an `afterAll`.
            * Each `failedExpectation` has a message that describes the failure and a stack trace.
            */
            Console.WriteLine("AfterAll " + result.FailedExpectations[i].Message);
            Console.WriteLine(result.FailedExpectations[i].Stack);
        }
    }
    /**
    * ### jasmineDone
    *
    * When the entire suite has finished execution `jasmineDone` is called
    */
    public void JasmineDone()
    {
        Console.WriteLine("Finished suite");
    }
}