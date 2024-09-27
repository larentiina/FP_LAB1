module Tests

open Xunit
open Palindrome 
open Polynomial

[<Fact>]
let ``isPalindrome should return true for a palindrome number`` () =
    let result = isPalindrome 121
    Assert.True(result, "Expected 121 to be a palindrome")

[<Fact>]
let ``isPalindrome should return false for a non-palindrome number`` () =
    let result = isPalindrome 123
    Assert.False(result, "Expected 123 to not be a palindrome")


[<Fact>]
let ``findLargestPalindromeTailRecursive should find the largest palindrome`` () =
    let result = findLargestPalindromeTailRecursive 999 999 0
    Assert.Equal(906609, result)


[<Fact>]
let ``findLargestPalindromeUsingList should return the largest palindrome`` () =
    let result = findLargestPalindromeUsingList ()
    Assert.Equal(906609, result)


[<Fact>]
let ``findLargestPalindromeUsingMap should return the largest palindrome`` () =
    let result = findLargestPalindromeUsingMap ()
    Assert.Equal(906609, result)


[<Fact>]
let ``findLargestPalindromeUsingSeq should return the largest palindrome`` () =
    let result = findLargestPalindromeUsingSeq ()
    Assert.Equal(906609, result)

let ``Test findBestCoefficientsRec`` () =
    let result = findBestCoefficientsRec 1000 1000 1000
    Assert.Equal(-59231, fst result) 
    Assert.Equal(62, snd result) 
    

[<Fact>]
let ``Test findBestCoefficientsList`` () =
    let result = findBestCoefficientsList 1000 1000 1000
    Assert.Equal(-59231, fst result) 
    Assert.Equal(62, snd result)
[<Fact>]
let ``Test findBestCoefficientsMap`` () =
    let result = findBestCoefficientsMap 1000 1000 1000
    Assert.Equal(-59231, fst result) 
    Assert.Equal(62, snd result) 

[<Fact>]
let ``Test findBestCoefficientsSeq`` () =
    let result = findBestCoefficientsSeq 1000 1000 1000
    Assert.Equal(-59231, fst result) 
    Assert.Equal(62, snd result)