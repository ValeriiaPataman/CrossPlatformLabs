# Лабораторна 5 

## Запуск застосунку
З теки WebApp виконайте
```bash
dotnet run
```
Та відкрийте http://localhost:5000 у веб-браузері

## Запуск на віртуальній машині
З теки Lab5 виконайте
```bash
vagrant up
```
Після завершення виконання vagrant up увійдіть до машини:
```bash
vagrant ssh
```
Перейдіть до папки з проектом:
```bash
cd /vagrant
```
Встановіть залежності та побудуйте проект:
```bash
dotnet restore
dotnet build
```
Запустіть команду:
```bash
dotnet run --project WebApp
```
