document.querySelectorAll('.quantity-form').forEach(form => {
    const field = form.querySelector('.quantity-field');
    const increaseBtn = form.querySelector('.increase-btn');
    const decreaseBtn = form.querySelector('.decrease-btn');

    increaseBtn.addEventListener('click', () => {
        field.stepUp();
        form.submit();
    });

    decreaseBtn.addEventListener('click', () => {
        field.stepDown();
        form.submit();
    });
});
