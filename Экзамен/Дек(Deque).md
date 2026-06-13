**Дек (Deque, Double-Ended Queue)** — это структура данных, которая объединяет в себе свойства стека (LIFO) и очереди (FIFO). Она позволяет добавлять и удалять элементы **с обоих концов** (и с начала, и с конца) за константное время $O(1)$.

Ниже подробно рассмотрены основные операции и два классических способа реализации дека.

---

### 1. Основные операции дека
Все базовые операции в правильной реализации дека имеют временную сложность **$O(1)$**

| Операция | Описание | Сложность |
| :--- | :--- | :--- |
| `push_front(x)` | Добавить элемент `x` в начало дека. | $O(1)$ |
| `push_back(x)` | Добавить элемент `x` в конец дека. | $O(1)$ |
| `pop_front()` | Удалить и вернуть элемент из начала дека. | $O(1)$ |
| `pop_back()` | Удалить и вернуть элемент из конца дека. | $O(1)$ |
| `peek_front()` | Вернуть элемент из начала дека без удаления. | $O(1)$ |
| `peek_back()` | Вернуть элемент из конца дека без удаления. | $O(1)$ |
| `is_empty()` | Проверить, пуст ли дек. | $O(1)$ |
| `size()` | Вернуть текущее количество элементов. | $O(1)$ |

---

### 2. Реализация через связный список (Двусвязный список)
Для реализации дека **обязательно** используется **двусвязный список** (Doubly Linked List). Односвязный список не подходит, так как удаление с конца (`pop_back`) в нем требует обхода всего списка ($O(N)$).
#### Структура:
*   Узел (`Node`): хранит значение, указатель на предыдущий узел (`prev`) и указатель на следующий узел (`next`).
*   Указатели `head` (голова) и `tail` (хвост).
*   Счетчик `size`.
#### Пример реализации на Python:
```python
class Node:
    def __init__(self, value):
        self.value = value
        self.prev = None
        self.next = None

class DequeLinkedList:
    def __init__(self):
        self.head = None
        self.tail = None
        self.size = 0

    def is_empty(self):
        return self.size == 0

    def push_front(self, value):
        new_node = Node(value)
        if self.is_empty():
            self.head = self.tail = new_node
        else:
            new_node.next = self.head
            self.head.prev = new_node
            self.head = new_node
        self.size += 1

    def push_back(self, value):
        new_node = Node(value)
        if self.is_empty():
            self.head = self.tail = new_node
        else:
            new_node.prev = self.tail
            self.tail.next = new_node
            self.tail = new_node
        self.size += 1

    def pop_front(self):
        if self.is_empty():
            raise IndexError("pop_front from empty deque")
        value = self.head.value
        self.head = self.head.next
        if self.head:
            self.head.prev = None
        else:
            self.tail = None # Дек стал пустым
        self.size -= 1
        return value

    def pop_back(self):
        if self.is_empty():
            raise IndexError("pop_back from empty deque")
        value = self.tail.value
        self.tail = self.tail.prev
        if self.tail:
            self.tail.next = None
        else:
            self.head = None # Дек стал пустым
        self.size -= 1
        return value
```

**Плюсы:**
*   Истинная сложность $O(1)$ для всех операций.
*   Нет необходимости в перевыделении памяти (resizing) или копировании элементов.
*   Память выделяется ровно под то количество элементов, которое есть.
**Минусы:**
*   Высокие накладные расходы на память (каждый элемент хранит два дополнительных указателя).
*   Плохая локальность данных (кэш-промахи), так как узлы разбросаны по куче (heap).
---
### 3. Реализация без связного списка (Кольцевой буфер / Динамический массив)
Использование обычного массива не подходит, так как `push_front` потребует сдвига всех элементов ($O(N)$). Решение — использование **кольцевого буфера** (Circular Buffer) на базе динамического массива.
#### Структура:
*   Массив фиксированного (или динамически расширяемого) размера `capacity`.
*   Индексы `head` (указывает на первый элемент) и `tail` (указывает на место, куда будет записан следующий элемент, или на последний элемент, в зависимости от реализации).
*   Счетчик `size` или `capacity`.
Логика кольцевого буфера: при достижении конца массива индекс "заворачивается" в начало по формуле: `index = (index + 1) % capacity`.
#### Пример реализации на Python:
```python
class DequeArray:
    def __init__(self, capacity=10):
        self.capacity = capacity
        self.data = [None] * capacity
        self.head = 0
        self.tail = 0
        self.size = 0

    def is_empty(self):
        return self.size == 0

    def _resize(self):
        # Увеличение массива в 2 раза при переполнении
        new_capacity = self.capacity * 2
        new_data = [None] * new_capacity
        
        # Копируем элементы в новый массив, начиная с 0, чтобы выровнять их
        for i in range(self.size):
            new_data[i] = self.data[(self.head + i) % self.capacity]
            
        self.data = new_data
        self.head = 0
        self.tail = self.size
        self.capacity = new_capacity

    def push_front(self, value):
        if self.size == self.capacity:
            self._resize()
        
        # Двигаем head назад (с учетом зацикливания)
        self.head = (self.head - 1 + self.capacity) % self.capacity
        self.data[self.head] = value
        self.size += 1

    def push_back(self, value):
        if self.size == self.capacity:
            self._resize()
            
        self.data[self.tail] = value
        self.tail = (self.tail + 1) % self.capacity
        self.size += 1

    def pop_front(self):
        if self.is_empty():
            raise IndexError("pop_front from empty deque")
            
        value = self.data[self.head]
        self.data[self.head] = None # Для сборщика мусора
        self.head = (self.head + 1) % self.capacity
        self.size -= 1
        return value

    def pop_back(self):
        if self.is_empty():
            raise IndexError("pop_back from empty deque")
            
        # Двигаем tail назад
        self.tail = (self.tail - 1 + self.capacity) % self.capacity
        value = self.data[self.tail]
        self.data[self.tail] = None
        self.size -= 1
        return value
```

**Плюсы:**
*   Отличная локальность данных (элементы лежат в непрерывном блоке памяти), что делает работу с кэшем процессора очень эффективной.
*   Меньшие накладные расходы на память (нет указателей `prev`/`next` для каждого элемента).
**Минусы:**
*   При заполнении массива требуется операция изменения размера (`_resize`), которая имеет сложность $O(N)$. Однако, поскольку это происходит редко, **амортизированная** сложность операций остается $O(1)$.