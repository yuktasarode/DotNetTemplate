const fetchBtn = document.getElementById("fetchBtn");
const message = document.getElementById("message");
const API_URL = "http://localhost:5018/api/players";

fetchBtn.addEventListener("click", async () => {

  try {
    message.textContent="Loading...";
    const response = await fetch(API_URL);

    if (!response.ok) {
      throw new Error("Failed to fetch data");
    }
    const players = await response.json();
    message.textContent = `Fetched ${players.length} players`;
    }
    catch (error) {
        console.log(error)
    }

});