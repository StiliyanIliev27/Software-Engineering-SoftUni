function attachEventsListeners() {
    function convertTime(time, timeType){
        if(timeType === 'days'){
            const hours = time * 24;
            const seconds = hours * 60 * 60;
            const minutes = hours * 60;
            return {hours, seconds, minutes};
        } else if(timeType === 'hours'){
            const minutes = time * 60;
            const seconds = minutes * 60;
            const days = time / 24;
            return {days, minutes, seconds};
        } else if(timeType === 'minutes'){
            const seconds = time * 60;
            const hours = time / 60;
            const days = hours / 24;
            return {days, hours, seconds};
        } else if(timeType === 'seconds'){
            const minutes = time / 60;
            const hours = minutes / 60;
            const days = hours / 24;
            return {days, hours, minutes};
        }
    }

    function transformData(timeType, result){
        switch(timeType){
            case 'days':
                document.getElementById('hours').value = result.hours;
                document.getElementById('minutes').value = result.minutes;
                document.getElementById('seconds').value = result.seconds;
            break;
            case 'hours':
                document.getElementById('days').value = result.days;
                document.getElementById('minutes').value = result.minutes;
                document.getElementById('seconds').value = result.seconds;
            break;
            case 'minutes':
                document.getElementById('days').value = result.days;
                document.getElementById('hours').value = result.hours;
                document.getElementById('seconds').value = result.seconds;
            break;
            case 'seconds':
                document.getElementById('days').value = result.days;
                document.getElementById('hours').value = result.hours;
                document.getElementById('minutes').value = result.minutes;
            break;
        }
    }

    function onClickHandler(event){
        const rawId = event.target.getAttribute('id');
        const inputId = rawId.replace('Btn', '');
        const inputEl = document.querySelector(`input#${inputId}`);

        const timeType = inputEl.id;
        const time = inputEl.value;
        
        const result = convertTime(time, timeType);
       
        transformData(timeType, result);
    }

    document.querySelectorAll('input[type=button]').forEach((buttonEl) => {
            buttonEl.addEventListener('click', onClickHandler);
    });
}