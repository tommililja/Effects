namespace Effects.Tests

open Effects.Api
open Effects.Monad
open Effects.Tests
open Xunit

module CatFactsTests =

    open Common

    [<Fact>]
    let ``getAsync should return cat facts`` () = async {

        let interpreter = TestInterpreter.defaultInterpreter

        let! facts =
            url
            |> CatFacts.getAsync
            |> EffectAsync.handle interpreter

        let first = List.head facts

        Expect.equal facts.Length 1
        Expect.equal first.Text "Cat fact"
    }
