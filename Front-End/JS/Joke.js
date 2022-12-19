const GetJoke = async function () {

    const req = await fetch("https://localhost:7205/DumbThings/GetJoke",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "GET",
            body: JSON.stringify()
        })

    const result = await req.json();

    const start = "Dumb Question: "
    const end = "Dumber Answer: "
        document.getElementById("startJoke").innerHTML = start.concat(result.setup)
        document.getElementById("endJoke").innerHTML = end.concat(result.punchline)
}
GetJoke()