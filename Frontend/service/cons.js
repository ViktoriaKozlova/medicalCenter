async function insertCons(
  idConclusion,
  date,
  information,
  reception,
  diseaseHistory
) {
  try {
    const body = JSON.stringify({
      idConclusion,
      date,
      information,
      reception,
      diseaseHistory,
    });
    const response = await fetch("http://localhost:5002/api/Conslusion", {
      method: "POST",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Cons was successfully added!");
  } catch (error) {
    console.log(error.message);
  }
}

async function deleteCons(idConclusion) {
  try {
    const response = await fetch(
      `http://localhost:5002/api/Conslusion/${idConclusion}`,
      {
        method: "DELETE",
      }
    );
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Cons was successfully delete!");
  } catch (error) {
    console.log(error.message);
  }
}
