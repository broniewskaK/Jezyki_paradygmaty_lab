from functools import reduce


def schedule_tasks(tasks):
    # sortowanie wg czasu zakończenia
    sorted_tasks = sorted(tasks, key=lambda x: x['end'])

    #reduce do wybrania zadań, które się nie nakładają
    selected_tasks = reduce(
        lambda selected, current: selected + [current] if not selected or current['start'] >= selected[-1][
            'end'] else selected,
        sorted_tasks,
        []
    )
    # obliczenie maks nagrody
    max_reward = sum(task['reward'] for task in selected_tasks)

    return max_reward, selected_tasks

tasks = [
    {'name': 'Zadanie 1', 'start': 1, 'end': 3, 'reward': 10},
    {'name': 'Zadanie 2', 'start': 2, 'end': 5, 'reward': 15},
    {'name': 'Zadanie 3', 'start': 4, 'end': 6, 'reward': 20},
    {'name': 'Zadanie 4', 'start': 6, 'end': 7, 'reward': 25},
    {'name': 'Zadanie 5', 'start': 5, 'end': 8, 'reward': 30},
]

max_reward, selected_tasks = schedule_tasks(tasks)

print(f"Maksymalna nagroda: {max_reward}")
print("Wybrane zadania:")
for task in selected_tasks:
    print(f"- {task['name']}: start = {task['start']}, end = {task['end']}, nagroda = {task['reward']}")
