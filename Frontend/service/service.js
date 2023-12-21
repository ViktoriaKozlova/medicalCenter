async function getService() {
  const response = await fetch("http://localhost:5002/api/Service", {
    method: "GET",
  });
  const result = await response.json();
  return result;
}

async function insertService(idService, nameService, price) {
  try {
    const body = JSON.stringify({ idService, nameService, price });
    const response = await fetch("http://localhost:5002/api/Service", {
      method: "POST",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Service was successfully added!");
  } catch (error) {
    console.log(error.message);
  }
}

async function newversionService(idService, nameService, price) {
  try {
    const body = JSON.stringify({ idService, nameService, price });
    const response = await fetch("http://localhost:5002/api/Service", {
      method: "PUT",
      body,
      headers: { "Content-Type": "application/json" },
    });
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Service was successfully update!");
  } catch (error) {
    console.log(error.message);
  }
}
async function deleteService(idService) {
  try {
    const response = await fetch(
      `http://localhost:5002/api/Service/${idService}`,
      {
        method: "DELETE",
      }
    );
    if (!response.ok) {
      throw new Error("Error");
    }
    console.log("Service was successfully delete!");
  } catch (error) {
    console.log(error.message);
  }
}
