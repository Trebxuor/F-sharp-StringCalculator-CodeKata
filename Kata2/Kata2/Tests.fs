namespace Kata2

module Tests =
    open NUnit.Framework

    [<Test>]
    let ``For an empty string should return 0``() =
        Assert.AreEqual(0, Kata.Add "")

    [<Test>]
    let ``For one number return thet number``() =
        Assert.AreEqual(1, Kata.Add "1")

    [<Test>]
    let ``For mulitple numbers seperated by a comma return sum``() =
        Assert.AreEqual(3, Kata.Add "1,2")

    [<Test>]
    let ``For multiple numbers seperated bya newline and comma return sum``() =
        Assert.AreEqual(6, Kata.Add "1,2\n3")

    [<Test>]
    let ``For custom delimeters should produce a sum``() =
        Assert.AreEqual(6, Kata.Add "//;\n1;2;3")

    [<Test>]
    let ``For any negative number throw an error with all in the message``() =
        try
            Kata.Add "-1,2,-3" |> ignore
            Assert.Fail("No exception")
        with
        | Failure msg -> Assert.AreEqual("-1;-3", msg)

    [<Test>]
    let ``Ignore numbers larger than 1000 in sum``() =
        Assert.AreEqual(4, Kata.Add "//;\n1;1001;3")

    [<Test>]
    let ``Custom delimeters of any length``() =
        Assert.AreEqual(6, Kata.Add "//[abc]\n1abc2abc3")

    [<Test>]
    let ``Multiple delimeters of single lenght``() =
        Assert.AreEqual(6, Kata.Add "//[a][b]\n1a2b3")

    [<Test>]
    let ``Multiple delimeters of multiple length``() =
        Assert.AreEqual(6, Kata.Add "//[abc][cba]\n1abc2cba3")
