/**
 * 
 * @param {Date} date 
 */
export const toKorString = (date) => {
    return date.getFullYear() + "-" +
        (date.getMonth() + 1).toString().padStart(2, "0") + "-"
        + date.getDate().toString().padStart(2, "0");
};
