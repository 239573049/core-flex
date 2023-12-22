var indexedDBs = [];

/**
 * 初始化IndexedDB
 * @param {*} id 唯一id
 * @param {*} databaseName 数据库名称 
 * @param {*} version 版本
 * @param {*} storeName 表名
 * @returns 
 */
export function open(id, databaseName, version, storeName) {
    // 如果indexedDBs存在则直接返回
    for (var i = 0; i < indexedDBs.length; i++) {
        if (indexedDBs[i].id == id) {
            return;
        }
    }

    return new Promise((resolve, reject) => {
        const request = indexedDB.open(databaseName, version);

        request.onupgradeneeded = (event) => {
            const db = event.target.result;
            if (!db.objectStoreNames.contains(storeName)) {
                db.createObjectStore(storeName, { keyPath: 'id', autoIncrement: true });
            }
        };

        request.onsuccess = (event) => {
            indexedDBs.push({
                id: id,
                db: event.target.result
            })
            resolve();
        };

        request.onerror = (event) => {
            reject(event.target.error);
        };
    });
}

function getDb(id) {
    for (var i = 0; i < indexedDBs.length; i++) {
        if (indexedDBs[i].id == id) {
            return indexedDBs[i].db;
        }
    }
    console.log("未找到指定id的indexedDB", id)
    return null;
}

/**
 * 查询指定storeName的所有数据
 */
export function getAll(id, storeName) {
    return new Promise((resolve, reject) => {
        var db = getDb(id);
        var store = db.transaction(storeName).objectStore(storeName);
        var request = store.getAll();
        request.onsuccess = function (event) {
            resolve(event.target.result);
        };
        request.onerror = function (event) {
            reject(event.target.error);
        };
    });
}

/**
 * 根据指定分页查询storeName数据
 * @param {*} id 
 * @param {*} storeName 
 * @param {*} page 
 * @param {*} pageSize 
 * @returns 
 */
export function getPage(id, storeName, page, pageSize) {
    return new Promise((resolve, reject) => {
        var db = getDb(id);
        var store = db.transaction(storeName).objectStore(storeName);

        var request = store.openCursor();
        var count = 0;
        var items = [];

        request.onsuccess = function (event) {
            var cursor = event.target.result;

            if (cursor) {
                count++;

                if (count > (page - 1) * pageSize && count <= page * pageSize) {
                    items.push(cursor.value);
                }

                if (count < page * pageSize) {
                    cursor.continue();
                } else {
                    resolve(items);
                }
            } else {
                // No more entries
                resolve(items);
            }
        };

        request.onerror = function (event) {
            reject(event.target.error);
        };
    });
}

/**
 * 添加数据
 * @param {*} id 
 * @param {*} storeName 
 * @param {*} value 
 * @returns 
 */
export function add(id, storeName, value) {
    return new Promise((resolve, reject) => {
        var db = getDb(id);
        var store = db.transaction(storeName, "readwrite").objectStore(storeName);
        var request = store.add(value);
        request.onsuccess = function(event) {
            resolve();
        };
        request.onerror = function(event) {
            console.error(event.target.error);
            reject();
        };

    });
}

/**
 * 更新指定数据
 * @param {any} id
 * @param {any} storeName
 * @param {any} value
 * @returns
 */
export function update(id, storeName, value) {
    return new Promise((resolve, reject) => {
        var db = getDb(id);
        var store = db.transaction(storeName, "readwrite").objectStore(storeName);
        var request = store.put(value);
        request.onsuccess = function (event) {
            resolve();
        };
        request.onerror = function (event) {
            console.error(event.target.error);
            reject();
        };

    })
}

/**
 * 删除指定key
 * @param {any} id
 * @param {any} storeName
 * @param {any} key
 * @returns
 */
export function remove(id, storeName, key) {
    return new Promise((resolve, reject) => {
        var db = getDb(id);
        var store = db.transaction(storeName, "readwrite").objectStore(storeName);
        var request = store.delete(key);
        request.onsuccess = function (event) {
            resolve();
        };
        request.onerror = function (event) {
            console.error(event.target.error);
            reject();
        };

    })
}

/**
 * 清空指定storeName的所有数据
 * @param {any} id
 * @param {any} storeName
 * @returns
 */
export function clear(id, storeName) {
    return new Promise((resolve, reject) => {
        var db = getDb(id);
        var store = db.transaction(storeName, "readwrite").objectStore(storeName);
        var request = store.clear();
        request.onsuccess = function (event) {
            resolve();
        };
        request.onerror = function (event) {
            console.error(event.target.error);
            reject();
        };

    })
}

/**
 * 批量删除key
 * @param {any} id
 * @param {any} storeName
 * @param {any} keys
 * @returns
 */
export function removes(id, storeName, keys) {
    return new Promise((resolve, reject) => {
        var db = getDb(id);
        var store = db.transaction(storeName, "readwrite").objectStore(storeName);
        for (let i = 0; i < keys.length; i++) {
            store.delete(keys[i]);
        }
    })
}

/**
 * 统计storeName的数据总数
 * @param {any} id
 * @param {any} storeName
 * @returns
 */
export function count(id, storeName) {
    return new Promise((resolve, reject) => {
        var db = getDb(id);
        var store = db.transaction(storeName).objectStore(storeName);
        var request = store.count();
        request.onsuccess = function (event) {
            resolve(event.target.result);
        };
        request.onerror = function (event) {
            console.error(event.target.error);
            reject();
        };

    })
}

/**
 * 关闭所有数据库对象
 */
export function closeAll() {
    for (var i = 0; i < indexedDBs.length; i++) {
        indexedDBs[i].close();
    }
}

/**
 * 关闭所有数据库对象
 */
export function close(id) {

    indexedDBs[i].close();
}

