def schedule_tasks(tasks):
    # sortowanie wg czasu zakonczeia
    tasks.sort(key=lambda x: x['end'])

    max_reward = 0
    selected_tasks = []
    last_end_time = 0

    for task in tasks:
        # warunek czy czas startu kolejnego zad nie koliduje z czasem zakończenia poprzedniego
        if task['start'] >= last_end_time:
            selected_tasks.append(task)  # dodanie do listy z harmonogramem
            max_reward += task['reward']  # powiekszenie nagrody o wartosc z zadania
            last_end_time = task['end']  # aktualizacja czasu zakonczenia na ten z obecnego zadania

    return max_reward, selected_tasks

tasks = [
    {'name': 'Zadanie 1', 'start': 1, 'end': 3, 'reward': 10},
    {'name': 'Zadanie 2', 'start': 2, 'end': 8, 'reward': 15},
    {'name': 'Zadanie 3', 'start': 4, 'end': 6, 'reward': 20},
    {'name': 'Zadanie 4', 'start': 6, 'end': 7, 'reward': 25},
    {'name': 'Zadanie 5', 'start': 5, 'end': 3, 'reward': 30},
]

max_reward, selected_tasks = schedule_tasks(tasks)

print(f"Maksymalna nagroda: {max_reward}")
print("Wybrane zadania:")
for task in selected_tasks:
    print(f"- {task['name']}: start = {task['start']}, end = {task['end']}, nagroda = {task['reward']}")
