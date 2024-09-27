open System
open Palindrome
open Polynomial


[<EntryPoint>]
let main argv =
    let resultTailRecursive = largestPalindromeTailRecursive()
    printfn "Largest palindrome (recursion): %d" resultTailRecursive

    let resultModule = findLargestPalindromeUsingList()
    printfn "Largest palindrome (List): %d" resultModule

    let resultMap = findLargestPalindromeUsingMap()
    printfn "Largest palindrome (map): %d" resultMap
    let resultSeq = findLargestPalindromeUsingSeq()
    printfn "Largest palindrome (seq): %d" resultSeq



    let multiABRec, maxCountRec = 
        findBestCoefficientsRec 1000 1000 1000

    

    printfn "Решение 27 задачи с использованием рекурсии:"
    printfn "Максимальное количество последовательных простых чисел: %d" maxCountRec
    printfn "Произведение a * b = %d" multiABRec
    printfn ""

    let multiABList, maxCountList = 
        findBestCoefficientsRec 1000 1000 1000

    printfn "Решение 27 задачи с использованием List:"
    printfn "Максимальное количество последовательных простых чисел: %d" maxCountList
    printfn "Произведение a * b = %d" multiABList

    let multiABMap, maxCountMap = 
        findBestCoefficientsRec 1000 1000 1000

    printfn "Решение 27 задачи с использованием Map:"
    printfn "Максимальное количество последовательных простых чисел: %d" maxCountMap
    printfn "Произведение a * b = %d" multiABMap

    let multiABSeq, maxCountSeq = 
        findBestCoefficientsRec 1000 1000 1000

    printfn "Решение 27 задачи с использованием Seq:"
    printfn "Максимальное количество последовательных простых чисел: %d" maxCountSeq
    printfn "Произведение a * b = %d" multiABSeq


    0