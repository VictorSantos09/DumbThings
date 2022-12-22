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
    elem.setAttribute("height", "500");
    elem.setAttribute("width", "500");
    elem.setAttribute("alt", "randomDogPic");

    document.getElementById("contentDog").appendChild(elem);
}

GetRandomDog()