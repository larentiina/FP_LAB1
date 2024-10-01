module Polynomial

// Хвостовая рекурсия для решета Эратосфена
let sieveOfEratosthenes n =
    let rec sieve numbers primes =
        match numbers with
        | [] -> primes
        | p :: xs ->
            let filtered = List.filter (fun x -> x % p <> 0) xs
            sieve filtered (p :: primes)

    let initialNumbers = [ 2..n ]
    sieve initialNumbers [] 


let isPrime primeSet value = Set.contains value primeSet

//Хвостовая рекурсия
let rec countPrimes a b n primeSet =
    let formula = n * n + a * n + b

    if isPrime primeSet formula then
        countPrimes a b (n + 1) primeSet
    else
        n

// Хвостовая рекурсия
let findBestCoefficientsRec limitA limitB maxPrime =
    let primes = sieveOfEratosthenes maxPrime
    let primeSet = Set.ofList primes

    let rec findBest a b maxCount maxA maxB =
        match a, b with
        | _ when a >= limitA -> (maxA * maxB, maxCount)
        | _ when b > limitB -> findBest (a + 1) -limitB maxCount maxA maxB
        | _ ->
            let count = countPrimes a b 0 primeSet

            let (newMaxCount, newMaxA, newMaxB) =
                if count > maxCount then
                    (count, a, b)
                else
                    (maxCount, maxA, maxB)

            findBest a (b + 1) newMaxCount newMaxA newMaxB

    findBest -limitA -limitB 0 0 0

// Реализация  с помощью List
let findBestCoefficientsList limitA limitB maxPrime =
    let primes = sieveOfEratosthenes maxPrime
    let primeSet = Set.ofList primes


    let countPrimesForAB a b = countPrimes a b 0 primeSet

    let pairs =
        [ for a in -limitA + 1 .. limitA - 1 do
              for b in -limitB .. limitB do
                  yield (a, b) ]


    let (maxA, maxB, maxCount) =
        pairs
        |> List.fold
            (fun (maxA, maxB, maxCount) (a, b) ->
                let count = countPrimesForAB a b

                if count > maxCount then
                    (a, b, count)
                else
                    (maxA, maxB, maxCount))
            (0, 0, 0)

    (maxA * maxB, maxCount)

//Генерация последовтельности с помщью map
let findBestCoefficientsMap limitA limitB maxPrime =
    let primes = sieveOfEratosthenes maxPrime
    let primeSet = Set.ofList primes


    let coeffs =
        [ -limitA + 1 .. limitA - 1 ]
        |> List.collect (fun a ->
            [ -limitB .. limitB ]
            |> List.map (fun b -> (a, b)))


    let results =
        coeffs
        |> List.map (fun (a, b) -> (a * b, countPrimes a b 0 primeSet))


    results |> List.maxBy snd

//Генерация последовтельности с помщью seq
let findBestCoefficientsSeq limitA limitB maxPrime =
    let primes = sieveOfEratosthenes maxPrime
    let primeSet = Set.ofList primes


    let coeffs =
        seq {
            for a in -limitA + 1 .. limitA - 1 do
                for b in -limitB .. limitB do
                    yield (a, b)
        }

    let results =
        coeffs
        |> Seq.map (fun (a, b) -> (a * b, countPrimes a b 0 primeSet))

    results |> Seq.maxBy snd
