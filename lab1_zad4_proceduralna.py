def knapsack(items, capacity):
    n = len(items)  # liczba przedmiotów
    # tablica do przechowywania maksymalnych wartości
    dp = [[0] * (capacity + 1) for _ in range(n + 1)]

    for i in range(1, n + 1):
        weight = items[i - 1]['weight']
        value = items[i - 1]['value']
        weight_value_product = weight * value  # waga * wartośc
        for w in range(1, capacity + 1):
            if weight_value_product <= w:
                dp[i][w] = max(dp[i - 1][w], dp[i - 1][w - weight_value_product] + value)
            else:
                dp[i][w] = dp[i - 1][w]

    # maksymalna wartość
    max_value = dp[n][capacity]
    selected_items = []
    w = capacity

    for i in range(n, 0, -1):  # iteracja wstecz
        weight = items[i - 1]['weight']
        value = items[i - 1]['value']
        weight_value_product = weight * value
        if max_value != dp[i - 1][w]:
            selected_items.append(items[i - 1])  # dodanie do listy
            w -= weight_value_product  # zmniejszenie wagi plecaka o weight_value_product
            max_value -= value  #zmniejszenie maksymalnej wartości

    return dp[n][capacity], selected_items

# przedmioty
items = [
    {'name': 'długopis', 'weight': 1, 'value': 2},
    {'name': 'zeszyt', 'weight': 1, 'value': 4},
    {'name': 'książka', 'weight': 1, 'value': 5},
    {'name': 'tablet', 'weight': 4, 'value': 1},
]


capacity = 12  # pojemnosc plecaka

# Wywołanie funkcji
max_value, selected_items = knapsack(items, capacity)

print(f"Maksymalna wartość w plecaku: {max_value}")
print("Wybrane przedmioty:")
for item in selected_items:
    print(f"- {item['name']}: waga = {item['weight']}, wartość = {item['value']}")
