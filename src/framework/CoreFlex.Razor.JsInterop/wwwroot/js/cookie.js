/***
 * 获取所有的 cookie
 * @returns {Promise<Array<Cookie>>} 包含所有 cookie 的 Promise 对象
 */
function getAllCookies() {
    return new Promise((resolve, reject) => {
        if (!window.cookieStore) {
            reject(new Error("cookieStore is not supported in this environment."));
            return;
        }

        const cookies = [];
        window.cookieStore.getAll().then(
            (cookieList) => {
                cookieList.forEach((cookie) => {
                    cookies.push(cookie);
                });
                resolve(cookies);
            },
            (error) => {
                reject(error);
            }
        );
    });
}

/***
 * 添加新的 cookie
 * @param {string} name cookie 名称
 * @param {string} value cookie 值
 * @param {number} [expirationDate] 过期时间（可选）
 * @returns {Promise<void>} 添加 cookie 的 Promise 对象
 */
function addCookie(name, value, expirationDate) {
    return new Promise((resolve, reject) => {
        if (!window.cookieStore) {
            reject(new Error("cookieStore is not supported in this environment."));
            return;
        }

        const cookieOptions = {
            name,
            value,
            expirationDate,
        };

        window.cookieStore.set(cookieOptions).then(
            () => {
                resolve();
            },
            (error) => {
                reject(error);
            }
        );
    });
}

// 导出函数
export { getAllCookies, addCookie };
