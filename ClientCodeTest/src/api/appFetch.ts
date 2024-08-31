const HEADERS = {
  "Content-Type": "application/json",
};

let base = "http://localhost:5215/api/";
export const appPost = async (url: string, params: object) => {
  let res = await fetch(`${base}${url}`, {
    method: "POST",
    headers: HEADERS,
    body: JSON.stringify({ ...params }),
  });
  const response = await res.json();
  return response;
};

export const appPatch = async (url: string, params: object) => {
  let res = await fetch(`${base}${url}`, {
    method: "PATCH",
    body: JSON.stringify({ ...params }),
  });
  const response = await res.json();
  return response;
};

export const appGet = async (url: string, params: object | null = null) => {
  let searchString = `${base}${url}`;
  if (params) {
    let initialized = false;
    for (const [key, value] of Object.entries(params)) {
      if (!initialized) searchString = searchString + "?" + key + "=" + value;
      else searchString = `${searchString}&${key}=${value}`;
      initialized = true;
    }
  }
  let res = await fetch(searchString, {
    method: "GET",
    headers: HEADERS,
  });
  const response = await res.json();
  return response;
};
