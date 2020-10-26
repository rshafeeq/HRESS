function isNumber(field) {
    var re = /^[0-9-' ']*$/;
    if (!re.test(field.value)) {
        alert("Value must be numbers, letter(s) not allowed!");
        field.value = field.value.replace(/[^0-9-' ']/g, "");
    }
}