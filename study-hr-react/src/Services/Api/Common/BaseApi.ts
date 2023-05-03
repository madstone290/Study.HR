import { config } from "Configurations/Config";
import { ContentMapper } from "Services/Api/Common/ContentMapper";

const apiUrl = config.apiUrl.endsWith("/")
    ? config.apiUrl
    : config.apiUrl + "/";


export class ApiResult<TData> {
    isSuccessful: boolean = false;
    message: string = "";
    data?: TData;

    static success<TData>(data?: TData) {
        const result = new ApiResult<TData>();
        result.isSuccessful = true;
        result.data = data;
        return result;
    }

    static fail<TData>(message: string) {
        const result = new ApiResult<TData>();
        result.isSuccessful = false;
        result.message = message;
        return result;
    }
}

export class BaseApi {
    async send<TResult>(method: string, route: string,
        bodyObj?: object,
        mapper?: ContentMapper<TResult>): Promise<ApiResult<TResult>> {
        if (apiUrl === "/")
            return ApiResult.fail<TResult>("Invalid api url");

        try {
            const response = await fetch(apiUrl + route,
                {
                    method: method,
                    headers: {
                        "Content-Type": "application/json"
                    },
                    body: bodyObj ? JSON.stringify(bodyObj) : null
                });
            if (!response.ok)
                return ApiResult.fail("Status " + response.statusText);

            let data: TResult | undefined;
            if (mapper) {
                data = await mapper.map(response);
            }
            return ApiResult.success<TResult>(data);
        } catch (error) {
            console.log(error);
            if (error instanceof Error)
                return ApiResult.fail(error.message);
            else if (typeof (error) === "string")
                return ApiResult.fail(error);
            else
                return ApiResult.fail("Unknown api error");
        }
    }

    async get<TData = number>(route: string, mapper?: ContentMapper<TData>): Promise<ApiResult<TData>> {
        return await this.send<TData>("GET", route, undefined, mapper);
    }

    async post<TData = number>(route: string, bodyObj?: object, mapper?: ContentMapper<TData>): Promise<ApiResult<TData>> {
        return await this.send<TData>("POST", route, bodyObj, mapper);
    }

    async put<TData = number>(route: string, bodyObj?: object, mapper?: ContentMapper<TData>): Promise<ApiResult<TData>> {
        return await this.send<TData>("PUT", route, bodyObj, mapper);
    }

    async delete<TData = number>(route: string, mapper?: ContentMapper<TData>): Promise<ApiResult<TData>> {
        return await this.send<TData>("DELETE", route, undefined, mapper);
    }
}

export const baseApi = new BaseApi();