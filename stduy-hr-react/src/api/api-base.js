import { config } from "../config";

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
    async send(method, route, jsonMapper = null, bodyObj = null) {
        const apiResult = new ApiResult();
        try {
            const response = await fetch(config.apiUrl + route,
                {
                    method: method,
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: bodyObj ? JSON.stringify(bodyObj) : null
                });
            if (!response.ok)
                return ApiResult.fail("Status " + response.statusText);

            const content = await response.json();
            const data = jsonMapper ? jsonMapper(content) : null;
            return ApiResult.success(data);
        } catch (error) {
            console.log(error);
            return ApiResult.fail(error.message);
        }
    }

    async get(route, jsonMapper = null) {
        return await this.send("GET", route, jsonMapper);
    }

    async post(route, jsonMapper = null, bodyObj = null) {
        return await this.send("POST", route, jsonMapper, bodyObj);
    }

    async put(route, jsonMapper = null, bodyObj = null) {
        return await this.send("PUT", route, jsonMapper, bodyObj);
    }

    async delete(route, jsonMapper = null) {
        return await this.send("DELETE", route, jsonMapper);
    }
}

export const api = new Api();