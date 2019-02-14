# puzzle. Как я решал тестовое задание

## Пролог
За 10+ лет работы ни в одной компании ни на одном проекте не приходилось решать подобные задачи, поэтому пришлось освежать в памяти теорию. В общем на решение задания у меня ушло наверное 12-16 часов.

И это было интересно!

## Графы, деревья, связность O_o
Когда я посмотрел на задание в голове начали всплывать такие термины:
* граф
* связный
* однонаправленный
* взвешенный
* дерево
* обход
* поиск в ширину
* поиск в глубину
* поиск пути
* Дейкстра
* бинарное дерево

### Игра "Пятнашки"!
На второй день пришло понимание, что задача еcть ничто иное как "Пятнашки" с немного изменёнными правилами! А я наверняка не первый, кто пытался решить "Пятнашки" программно. Google подсказал множество вариантов решения. Но глаз зацепился за [алгоритм **A\***](https://ru.wikipedia.org/wiki/A*). Быстро нашлись статьи ([статья 1](https://www.dokwork.ru/2012/03/blog-post.html), [статья 2](https://www.pvsm.ru/java/16174)), благодаря которым я понял принцип программной реализацию. 
Теперь остаавалось только "заточить" алгоритм под нашу "карту". Т.е. ходы можно делать по поределёным правилам, отличным от "Пятнашек".

### Реализация
За основу был взят код из статей, приведённых выше. При реализации на C# я использовал готовую библиотеку [OptimizedPriorityQueue](https://www.nuget.org/packages/OptimizedPriorityQueue/), чтобы не "писать велосипед".

Для тестов использовал NUnit для C# и xUnit для F#.

В качестве DI контейнера использовал SimpleInjector.

Весь этот набор библиотек использован только для того, чтобы показать, что я умею и работаю с ними.

## Другие варианты
Если бы было больше времени и стояла такая задача, то я мог бы выполнить это задание с пименением других алгоритмов (в ширину, в глубину) а также немного оптимизировал выбранный. Можно было бы сравнить производительность всех алгоритмов.

## Мультипоточность

Одним из пунктов задания был "теоретическое масштабирование решения для работы на кластере". В коде про это ничего нет. Но если говорить словами, то единственной точкой масштабирования я вижу цикл ветвления состояния игрового поля. Этот процесс можно было бы распараллелить на несколько потоков, а потом собрать водеино результаты и найти кратчайший путь. Но это для "жадных" алгоритмов. Для выбранного мною алгоритма А* оптимальный путь строится практически сразу и распараллеливать его не вижу возможным.
Так же я наслышан о лёгкой возможности параллелизма в F# за счёт иммутабельности структур данных, но как это сделать в данном конкретном примере не представляю.

## Что можно было бы улучшить
1. Эвристику можно было бы взять более точную (Манхэттэнское расстояние)
2. Можно было бы поискать (или попытаться вывести) правило разрешимости головоломки. Чтобы даже не пытаться её решать если это невозможно. Для "Пятнашек" такое правило известно. Для вашего варианта "доски" - не нашёл.


## Полезные ссылки
- [Алгоритм **A\*** на Википедии](https://ru.wikipedia.org/wiki/A*)
- [Очень наглядно про A* на Хабре](https://habr.com/ru/post/331192/)
- [Интеллектуальные системы. Алгоритм A* и игра "Пятнашки"](https://www.dokwork.ru/2012/03/blog-post.html)
- [А* для нахождения решения «пятнашек»](https://www.pvsm.ru/java/16174)
- [Библиотека очередей с приоритетом Optimized Priority Queue](https://www.nuget.org/packages/-OptimizedPriorityQueue/)
