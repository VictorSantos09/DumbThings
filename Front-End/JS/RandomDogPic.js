const elem = document.createElement("img");

const GetRandomDog = async function (id) {
    const req = await fetch("https://localhost:7205/DumbThings/GetRandomDog",
        {
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            method: "GET",
            body: JSON.stringify()
        })

    const result = await req.json();

    document.getElementById(id).setAttribute("src", result.message);
    document.getElementById(id).setAttribute("height", "300");
    document.getElementById(id).setAttribute("width", "300");
    document.getElementById(id).setAttribute("alt", "Random Dog Picture");
    document.getElementById(id).setAttribute("class", "border-style");
}

function CallAll() {
    GetRandomDog("dog-1")
    GetRandomDog("dog-2")
    GetRandomDog("dog-3")
    GetRandomDog("dog-4")
    GetRandomDog("dog-5")
    GetRandomDog("dog-6")
    GetRandomDog("dog-7")
    GetRandomDog("dog-8")
}

CallAll()

document.getElementById("seeMoreDogs").addEventListener("click", () => CallAll())