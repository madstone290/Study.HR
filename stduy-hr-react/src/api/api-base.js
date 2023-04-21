import { config } from "../config";

const apiUrlSlash = config.apiUrl.endsWith("/")
    ? config.apiUrl
    : config.apiUrl + "/";

export class ApiResult {
    isSuccessful = false;
    message = "";
    data = {};

    static success(data) {
        const result = new ApiResult();
        result.isSuccessful = true;
        result.data = data;
        return result;
    }

    static fail(message) {
        const result = new ApiResult();
        result.isSuccessful = false;
        result.message = message;
        return result;
    }
}

export class Api {
    async send(method, route, bodyObj, { jsonMapper, textMapper }) {
        try {
            const response = await fetch(apiUrlSlash + route,
                {
                    method: method,
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: bodyObj ? JSON.stringify(bodyObj) : null
                });
            if (!response.ok)
                return ApiResult.fail("Status " + response.statusText);

            let data = null;
            if (jsonMapper) {
                const json = await response.json();
                data = jsonMapper(json);
            }
            else if (textMapper) {
                const text = await response.text();
                data = textMapper(text);
            }

            return ApiResult.success(data);
        } catch (error) {
            console.log(error);
            return ApiResult.fail(error.message);
        }
    }

    async get(route, { jsonMapper, textMapper }) {
        return await this.send("GET", route, null, { jsonMapper, textMapper });
    }

    async post(route, bodyObj, { jsonMapper, textMapper }) {
        return await this.send("POST", route, bodyObj, { jsonMapper, textMapper });
    }

    async put(route, bodyObj, { jsonMapper, textMapper }) {
        return await this.send("PUT", route, bodyObj, { jsonMapper, textMapper });
    }

    async delete(route, { jsonMapper, textMapper }) {
        return await this.send("DELETE", route, null, { jsonMapper, textMapper });
    }
}

export const api = new Api();