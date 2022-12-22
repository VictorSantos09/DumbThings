const Activity = async function () {

    const req = await fetch("https://localhost:7205/DumbThings/GetBoredActivity",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "GET",
            body: JSON.stringify()
        })

    const result = await req.json();

    const start = "So sad u are bored "
    const end = "Try to "
    document.getElementById("answerActivity").innerHTML = end.concat(result.activity)
}
Activity()