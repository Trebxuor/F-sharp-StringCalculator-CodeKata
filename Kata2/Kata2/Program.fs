namespace Kata2
open System.Text.RegularExpressions
open System

module Kata =
    let convertArrayToRegex stringArray =
        String.concat "|" (Array.filter (fun a -> a <> "") stringArray)

    let convertToIntArrayAndSum stringArray =
        let intNumberArray = Array.map int stringArray
        let numbersSmallerThan1001 = Array.filter (fun a -> a < 1001) intNumberArray
        let negatives = Array.filter (fun a -> a < 0) intNumberArray
        match negatives.Length > 0 with
        | true -> failwith (String.Join(";", negatives))
        | false -> Array.sum numbersSmallerThan1001

    let Add numbers =
        match Seq.toList numbers with
        | [] -> 0
        | '/'::'/'::'['::remainder ->
            let delimsAndNumbers = String.Concat remainder
            let delimsString = delimsAndNumbers.Substring(0, delimsAndNumbers.IndexOf("\n"))
            let numbersString = delimsAndNumbers.Substring(delimsAndNumbers.IndexOf("\n"))
            let delimsArray = Regex.Split(delimsString, "\]\[|\]|\[")
            convertToIntArrayAndSum (Regex.Split(numbersString, convertArrayToRegex delimsArray))
        | '/'::'/'::delim::'\n'::remainder ->
            let numberArray = Regex.Split(String.Concat remainder, string delim)
            convertToIntArrayAndSum numberArray
        | _ ->
            let numberArray = Regex.Split(numbers, ",|\n")
            convertToIntArrayAndSum numberArray
