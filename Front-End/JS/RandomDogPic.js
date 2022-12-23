const GetRandomDog = async function (){
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

    var elem = document.createElement("img");

    elem.setAttribute("src", result.message);
    elem.setAttribute("height", "300");
    elem.setAttribute("width", "300");
    elem.setAttribute("alt", "Random Dog Picture");

    document.getElementById("image-dog-placeholder").appendChild(elem);
}

GetRandomDog()