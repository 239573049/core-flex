// storage.js

/**
 * 设置 sessionStorage 中的值
 * @param {string} key - 存储的键名
 * @param {any} value - 存储的值
 */
export function setSessionStorageItem(key, value) {
    try {
        sessionStorage.setItem(key, value);
    } catch (error) {
        console.error('Error setting sessionStorage item:', error);
    }
}

/**
 * 获取 sessionStorage 中的值
 * @param {string} key - 要检索的键名
 * @returns {any} - 存储的值，如果不存在则返回 null
 */
export function getSessionStorageItem(key) {
    try {
        const storedValue = sessionStorage.getItem(key);
        return storedValue;
    } catch (error) {
        console.error('Error getting sessionStorage item:', error);
        return null;
    }
}

/**
 * 移除 sessionStorage 中的值
 * @param {string} key - 要移除的键名
 */
export function removeSessionStorageItem(key) {
    try {
        sessionStorage.removeItem(key);
    } catch (error) {
        console.error('Error removing sessionStorage item:', error);
    }
}

/**
 * 清空 sessionStorage
 */
export function clearSessionStorage() {
    try {
        sessionStorage.clear();
    } catch (error) {
        console.error('Error clearing sessionStorage:', error);
    }
}

/**
 * 获取 sessionStorage 中的键名
 * @returns {string[]} - 存储的所有键名
 */
export function getSessionStorageKeys() {
    try {
        return Object.keys(sessionStorage);
    } catch (error) {
        console.error('Error getting sessionStorage keys:', error);
        return [];
    }
}

/**
 * 获取 sessionStorage 中值的数量
 * @returns {number} - 存储的值的数量
 */
export function getSessionStorageLength() {
    try {
        return sessionStorage.length;
    } catch (error) {
        console.error('Error getting sessionStorage length:', error);
        return 0;
    }
}

/***
 * 判断sessionStorage中是否存在某个key
 */
export function containKey(key) {
    try {
        if (sessionStorage.getItem(key)) {
            return true;
        } else {
            return false;
        }
    } catch (e) {
        console.error('Error getting sessionStorage length:', e);
        return false;
    } 
}