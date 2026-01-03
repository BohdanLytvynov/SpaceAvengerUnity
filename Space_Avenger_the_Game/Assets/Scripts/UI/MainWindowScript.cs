using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UIElements.Experimental;
using System.Collections.Generic;

public class MainWindowScript : MonoBehaviour
{
    Button m_exitButton;

    private void OnEnable()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        // Используем точное имя класса из вашего дебаггера
        var btns = root.Query<Label>(className: "h1-label").ToList();

        foreach (var btn in btns)
        {
            StartBlinking(btn, 1f, 0.3f);
        }

        m_exitButton = root.Query<Button>(name: "Exit_Button").First();

        if(m_exitButton != null)
        {
            m_exitButton.clicked += () =>
            { 
                ExitGame();
            };
        }
    }

    private void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Exit Game...");
#endif
    }

    private void OnDisable()
    {
        m_exitButton.clicked -= () => { };
    }

    private void StartBlinking(Label button, float from, float to)
    {
        // Создаем анимацию
        ValueAnimation<float> anim = button.experimental.animation.Start(
            from,
            to,
            1000,
            (elem, val) => elem.style.opacity = val
        );

        anim.Ease(Easing.InOutSine);
        anim.KeepAlive();

        // Когда анимация дошла до конца (например, от 1 до 0.3)
        anim.OnCompleted(() =>
        {
            // Запускаем её в обратную сторону (от 0.3 до 1)
            StartBlinking(button, to, from);
        });
    }
}