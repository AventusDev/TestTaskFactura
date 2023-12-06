# TestTaskFactura Unity 2022.3.10f1

При виконанні завдання я орієнтувався на приниципи <b>KISS</b> та <b>SOLID</b>.

Основні паттерни використані в проекті:

<b>Factory</b> - для спавна стікменів. Спавн відбувається в рандомних координатах в кастомній зоні.

<b>ObjectPool</b> - для пула куль, які летять із турелі. Пул реалізований через "UnityEngine.Pool", я не став писати свій кастомний пул, тому що в цьому не було потреби, UnityEngine.Pool достатньо гнучкий і має хорошу реалізацію + зберігає обєкти в стеку. Пул реалізований для куль, але його можна було б використати і для стікменів, якщо би левели були довшими. Партикл який програється при зіткненні кулі із стікменом або стікмена із гравцем існує в одному екземплярі на протязі всієї гри, він змінює свою позицію і програється заново кожного разу коли це потрібно, тому для нього пул не потрібний.

<b>EventBus</b> - використовується для зберігання та викликів івентів. У нього проста реалізація в синглтоні, його можна було б реалізувати складніше, із можливістю задавати пріорітети для різних івентів і т.д., але для задач із завдання в цьому немає потреби.

Dependeny Injection не використовувався, оскільки проект маленький і в ньому лише кор механіка.

Зміна камер відбувається через <b>Cinemachine</b> і її віртуальні камери.
Світло запікалось з використанням lighting probes.

Візуальні ефекти із паку **Epic Toon FX**. Шейдер із **Toony Colors Pro**.
