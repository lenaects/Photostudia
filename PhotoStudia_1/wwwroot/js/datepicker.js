window.initDatePicker = (inputId, unavailableDates, dotNetHelper) => {
    const input = document.getElementById(inputId);
    if (!input) return;

    input.placeholder = "Выберите дату съёмки"; // <-- вот здесь подпись

    flatpickr(input, {
        dateFormat: "Y-m-d",
        disable: unavailableDates,
        minDate: "today",
        onChange: function (selectedDates, dateStr) {
            dotNetHelper.invokeMethodAsync('OnDateSelected', dateStr);
        }
    });
};  

window.updateDatePicker = (inputId, unavailableDates) => {
    const input = document.getElementById(inputId);
    if (!input || !input._flatpickr) return;

    input._flatpickr.set('disable', unavailableDates);
};