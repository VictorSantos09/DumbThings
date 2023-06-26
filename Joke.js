const GetJoke = async function (id) {
    const req = await fetch(" https://icanhazdadjoke.com/",
    {
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        method: "GET",
    })

const result = await req.json()
    const div = document.createElement("div")
    const h3Start = document.createElement("h3").innerHTML = "Dumb Joke: ".concat(result.joke)
    const br = document.createElement("br")

    div.append(h3Start, br)
    document.getElementById(id).appendChild(div)
}

function CallAllJokes() {
    GetJoke("joke-1")
   GetJoke("joke-2")
   GetJoke("joke-3")
   GetJoke("joke-4")
}

function CleanAndCall() {
    document.getElementById("joke-1").innerHTML = ""
    document.getElementById("joke-2").innerHTML = ""
    document.getElementById("joke-3").innerHTML = ""
    document.getElementById("joke-4").innerHTML = ""
    CallAllJokes()
}

CallAllJokes()
document.getElementById("SeeNewJokes").addEventListener("click", () => CleanAndCall())