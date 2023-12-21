async function getReception() {
  const response = await fetch("http://localhost:5002/api/Reception", {
    method: "GET",
  });
  const result = await response.json();
  return result;
}

async function insertReception(
  idReception,
  date,
  time,
  visit,
  user,
  serviceId,
  doctorId
) {
  try {
    const body = JSON.stringify({
      idReception,
      date,
      time,
      visit,
      user,
      serviceId,
      doctorId,
    });
    const response = await fetch("http://localhost:5002/api/Reception", {
      method: "POST",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Reception was successfully added!");
  } catch (error) {
    console.log(error.message);
  }
}

async function deleteReception(idReception) {
  try {
    const response = await fetch(
      `http://localhost:5002/api/Reception/${idReception}`,
      {
        method: "DELETE",
      }
    );
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Reception was successfully delete!");
  } catch (error) {
    console.log(error.message);
  }
}
