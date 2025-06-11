document.addEventListener("DOMContentLoaded", () => {
    const inputs = document.querySelectorAll(".code-inputs input");
    inputs.forEach(input => {
        input.addEventListener("keypress", function (e) {
            if (!/[0-9]/.test(e.key)) {
                e.preventDefault(); // Блокирует всё, кроме цифр
            }
        });
    });
});

window.focusNextInput = function (index) {
    const inputs = document.querySelectorAll('.code-inputs input');
    if (index + 1 < inputs.length) {
        inputs[index + 1].focus();
    }
};
