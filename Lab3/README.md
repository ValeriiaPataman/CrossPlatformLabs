# Лабораторна 3
## Варіант 34

У постіндустріальну епоху основною цінністю є інформація. Тому особливо важливим є контроль над каналами передачі інформації. У країні всі канали зв'язку контролюються державою.

Перед ІТ-відділом однієї досить великої фірми, що займається консалтингом у галузі інноваційних технологій, було поставлено завдання поширити якийсь файл по філіях цієї фірми, що знаходяться у різних містах країни.

Канали передачі інформації в цій країні, як уже говорилося, контролюються державою, тому за передачу інформації доводиться платити гроші. Ситуація також ускладнюється тим, що канали односпрямовані, тобто інформацію щодо них можна передавати лише в одному напрямку.

Нехай для зручності міста пронумеровані натуральними числами від 1 до n. Головний офіс знаходиться в місті номер 1, таким чином, необхідно знайти такий набір каналів зв'язку, якими можна доставити файл від міста номер 1 до будь-якого іншого, а серед усіх таких наборів вибрати найменшу сумарну вартість.

Задано список каналів зв'язку, якими може користуватися компанія. Напишіть програму, яка містить потрібний набір каналів зв'язку.

**Вхідні дані**

Перший рядок вхідного файлу INPUT.TXT містить числа n і m - кількість міст і кількість каналів зв'язку відповідно (1 ≤ n ≤ 22, 0 ≤ m ≤ 22). Наступні m містять опис каналів зв'язку. Кожен опис містить три цілих числа: u, v і c - відповідно номери міст, з'єднаних каналом і вартість пересилання файлу цим каналом (1 ≤ u, v ≤ n, 0 ≤ c ≤ 1000). Жоден із каналів не з'єднує місто із самим собою, але між двома містами може бути більше одного каналу.

**Вихідні дані**

У першому рядку вихідного файлу OUTPUT.TXT виведіть вартість пересилання файлу та кількість каналів, які забезпечують таку вартість. У другому рядку виведіть номери каналів, що становлять такий набір. Канали нумеруються від 1 до m у тому порядку, в якому вони перераховані у вхідному файлі.

**Приклади**

| №  | INPUT.TXT     | OUTPUT.TXT |
|----|---------------|------------|
| 1  | 2 2           | 3 1        |
|    | 1 2 3         | 1          |
|    | 1 2 4         |            |
| 2  | 3 3           | 14 2       |
|    | 1 2 5         | 2 3        |
|    | 1 3 10        |            |
|    | 3 2 4         |            |


## Run Locally lab3

Зібрати застосунок:

```bash
  dotnet build Build.proj -p:Solution=Lab3 -t:Build
```

Запустити застосунок:

```bash
  dotnet build Build.proj -p:Solution=Lab3 -t:Run
```


## Test lab3

```bash
  dotnet build Build.proj -p:Solution=Lab3 -t:Test
```

