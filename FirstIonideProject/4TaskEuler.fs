module Palindrome

// Обычная рекурсия
let isPalindrome n =
    let rec check (str: string) (i: int) (j: int) =
        match i >= j, str.[i] = str.[j] with
        | true, _ -> true
        | false, false -> false
        | false, true -> check str (i + 1) (j - 1)
    
    let str = string n
    check str 0 (str.Length - 1)

// Хвостовая рекурсия

let rec findLargestPalindromeTailRecursive x y maxPalindrome =
    match x, y with
    | x, _ when x < 100 -> maxPalindrome
    | _, y when y < 100 -> findLargestPalindromeTailRecursive (x - 1) 999 maxPalindrome
    | _ ->
        let product = x * y
        let newMax = if isPalindrome product && product > maxPalindrome then product else maxPalindrome
        findLargestPalindromeTailRecursive x (y - 1) newMax

let largestPalindromeTailRecursive () =
    findLargestPalindromeTailRecursive 999 999 0
    
// Модульная реализация с List
let findLargestPalindromeUsingList () =
    let products = [for x in 100..999 do for y in 100..999 -> x * y]
    products
    |> List.filter isPalindrome
    |> List.max

// Генерация последовательности при помощи map
let findLargestPalindromeUsingMap () =
    let products =
        [100..999]
        |> List.collect (fun x -> 
            [100..999]
            |> List.map (fun y -> x * y))
    products
    |> List.filter isPalindrome
    |> List.max

// Бесконечная последовательнось
let generateProducts () =
    seq {
        for x in 999 .. -1 .. 100 do
            for y in x .. -1 .. 100 do
                yield x * y
    }

let findLargestPalindromeUsingSeq () =
    generateProducts()
    |> Seq.filter isPalindrome
    |> Seq.max




