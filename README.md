
## Лабораторная работа №1 по F#

Кузенина Валерия P3233

## Задачи Эйлера №4 и №27

### Описание задач

1. **Задача №4**: Найти самый большой палиндром, полученный умножением двух трёхзначных чисел.
2. **Задача №27**: Рассматриваются квадратичные выражения вида: $n^2 + an + bn$

$где |a| < 1000∣a∣<1000 и |b| \leq 1000∣b∣≤1000 (то есть a и b — целые числа).$

Найдите такие коэффициенты a и b, для которых выражение порождает максимальное количество последовательных простых чисел для значений n, начиная с n = 0.

---

## Задача №4: Найти 10001-е простое число

### Постановка задачи

Найти самый большой палиндром, полученный умножением двух трёхзначных чисел.
### Решения

#### 1. Простая рекурсия
Используем её для проверки является ли число палиндромом

```fsharp
let isPalindrome n =
    let rec check (str: string) (i: int) (j: int) =
        match i >= j, str.[i] = str.[j] with
        | true, _ -> true
        | false, false -> false
        | false, true -> check str (i + 1) (j - 1)

    let str = string n
    check str 0 (str.Length - 1)

```

#### 2. Хвостовая рекурсия
Используем её для основной функции перебора пар 3х значных чисел. В параметрах она хранит пару и текущий максимальный палиндром

```fsharp
let rec findLargestPalindromeTailRecursive x y maxPalindrome =
    match x, y with
    | x, _ when x < 100 -> maxPalindrome
    | _, y when y < 100 -> findLargestPalindromeTailRecursive (x - 1) 999 maxPalindrome
    | _ ->
        let product = x * y

        let newMax =
            if isPalindrome product && product > maxPalindrome then
                product
            else
                maxPalindrome

        findLargestPalindromeTailRecursive x (y - 1) newMax
```

#### 3. Модульное решение
С помощью функций высшего порядка фильтруем коллекцию из произведений 3х значных чисел и ищем максимальное из них
```fsharp
let findLargestPalindromeUsingList () =
    let products =
        [ for x in 100..999 do
              for y in 100..999 -> x * y ]

    products |> List.filter isPalindrome |> List.max
```

#### 4. Использование `map`
Сначала используем List.map для преобразование коллекции в массив произведений a и b
```fsharp
let findLargestPalindromeUsingMap () =
    let products =
        [ 100..999 ]
        |> List.collect (fun x -> [ 100..999 ] |> List.map (fun y -> x * y))

    products |> List.filter isPalindrome |> List.max
```

#### 5. Ленивая коллекция

```fsharp
let generateProducts () =
    seq {
        for x in 999..-1..100 do
            for y in x .. -1 .. 100 do
                yield x * y
    }

let findLargestPalindromeUsingSeq () =
    generateProducts ()
    |> Seq.filter isPalindrome
    |> Seq.max

```

### решение на Java

```java
public class 4Euler{

    private static boolean isPalindrom(int n){
        String str = String.valueOf(n);
        if(str.length()==6){
            return (str.charAt(0) == str.charAt(5)) && str.charAt(1) == str.charAt(4) && str.charAt(2) == str.charAt(3);
        }
        return false;
    }

    public static int solveProblem(){
        int max = 0;
        for(int i = 100; i<=999;i++){
            for(int j = i; j<=999;j++){
                if(isPalindrom(i*j)){
                    max = Math.max(max,i*j);
                }
            }
        }
        return max;
    }

}  
```

## Задача №27: 

### Постановка задачи

Рассматриваются квадратичные выражения вида: $n^2 + an + bn$

$где |a| < 1000∣a∣<1000 и |b| \leq 1000∣b∣≤1000 (то есть aa и bb — целые числа).$

Найдите такие коэффициенты a и b, для которых выражение порождает максимальное количество последовательных простых чисел для значений n, начиная с n = 0.
### Решения

#### 1. Простая рекурсия
Используем её для нахождения простых чисел с помjщью алгоритма рето Эратосфена

```fsharp
let sieveOfEratosthenes n =
    let rec sieve numbers primes =
        match numbers with
        | [] -> List.rev primes
        | p :: xs ->
            let filtered = List.filter (fun x -> x % p <> 0) xs
            sieve filtered (p :: primes) // Обновляем список простых чисел

    let initialNumbers = [ 2..n ]
    sieve initialNumbers [] 

```

#### 2. Хвостовая рекурсия
Используем её для подсчёта текущей последовательности для конкретных a и b

```fsharp
let rec countPrimes a b n primeSet =
    let formula = n * n + a * n + b

    if isPrime primeSet formula then
        countPrimes a b (n + 1) primeSet
    else
        n

```

#### 3. Модульное решение
С помощью функции высшего порядка List.fold сворачиваем массив пар (a,b) в 1 структуру (maxA, maxB, maxCount)

```fsharp
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
```

#### 4. Использование `map`
Сначала используем List.map для создания коллекции пар (a,b). Потом эту коллекцию преобразуем в пару с произведением a и b и длина последовательности для этого произведения
```fsharp
 let coeffs =
        [ -limitA + 1 .. limitA - 1 ]
        |> List.collect (fun a ->
            [ -limitB .. limitB ]
            |> List.map (fun b -> (a, b)))


    let results =
        coeffs
        |> List.map (fun (a, b) -> (a * b, countPrimes a b 0 primeSet))


    results |> List.maxBy snd
    
```

#### 5. Ленивая коллекция

```fsharp
    let coeffs =
        seq {
            for a in -limitA + 1 .. limitA - 1 do
                for b in -limitB .. limitB do
                    yield (a, b)
        }
```


### решение на Java

```java

public class Euler27 {

 
    public static boolean isPrime(int n) {
        if (n < 2) return false;
        for (int i = 2; i * i <= n; i++) {
            if (n % i == 0) return false;
        }
        return true;
    }

    public static int consecutivePrimes(int a, int b) {
        int n = 0;
        while (isPrime(n * n + a * n + b)) {
            n++;
        }
        return n;
    }

    public static void main(String[] args) {
        int maxPrimes = 0;
        int bestA = 0;
        int bestB = 0;
        for (int a = -999; a < 1000; a++) {
            for (int b = -1000; b <= 1000; b++) {
                int numPrimes = consecutivePrimes(a, b);
                if (numPrimes > maxPrimes) {
                    maxPrimes = numPrimes;
                    bestA = a;
                    bestB = b;
                }
            }
        }

}
```

## Выводы


Я ознакомилась с языком F#, узнала его синтаксис, операторы и функции. Синтаксис и разные операторы немного непривычны для меня, но это оказалось несложно освоить. Эта лабораторная работа позволила мне увидеть, как функциональное программирование может быть использовано для решения сложных задач. Я сделала небольшие выводы, пока делала реализации решений:

Например, простая рекурсия удобна для базовых решений, а модульное решение делает код более структурированным. Попробовала также для решения задач метода как хвостовую рекурсию, использование `map` и ленивые коллекции.
