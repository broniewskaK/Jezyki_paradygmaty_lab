def knapsack(items, capacity, n):
    # gdy nie ma przedmiotow albo pojemnosc plecaka wynosi 0
    if n == 0 or capacity == 0:
        return 0, []

    weight = items[n - 1]['weight']
    value = items[n - 1]['value']
    weight_value_product = weight * value

    # gdy przemdiot sie nie miesci prechodzi do kolejnego
    if weight_value_product > capacity:
        return knapsack(items, capacity, n - 1)

    #obliczanie wartości, gdy przedmiot jest dodany lub pominięty
    value_included, selected_items_included = knapsack(items, capacity - weight_value_product, n - 1)
    value_excluded, selected_items_excluded = knapsack(items, capacity, n - 1)
    if value + value_included > value_excluded:  # wybierana wyzsza wartosc
        return value + value_included, selected_items_included + [items[n - 1]]
    else:
        return value_excluded, selected_items_excluded


items = [
    {'name': 'długopis', 'weight': 1, 'value': 1},
    {'name': 'zeszyt', 'weight': 2, 'value': 2},
    {'name': 'książka', 'weight': 2, 'value': 2},
    {'name': 'tablet', 'weight': 4, 'value': 1},
]
capacity = 10  #pojemnosć plecaka
max_value, selected_items = knapsack(items, capacity, len(items))


print(f"Maksymalna wartość w plecaku: {max_value}")
print("Wybrane przedmioty:")
for item in selected_items:
    print(f"- {item['name']}: waga = {item['weight']}, wartość = {item['value']}")
