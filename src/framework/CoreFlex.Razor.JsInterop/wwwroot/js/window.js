/**
 * 生成 Blob 对象的 URL
 * @param {Blob} blob - 要创建 URL 的 Blob 对象
 * @returns {string} - Blob 对象的 URL
 * @throws {Error} - 如果创建 URL 失败，则抛出异常
 */
export function createBlobURL(blob) {
    try {
        return (window.URL || window.webkitURL || window || {}).createObjectURL(blob);
    } catch (error) {
        throw new Error('创建 URL 失败: ' + error.message);
    }
}

/**
 * 生成 Blob 对象的 URL，接受 byte[] 数据
 * @param {Uint8Array} data - 要创建 URL 的 byte[] 数据
 * @param {string} [type] - Blob 的 MIME 类型
 * @returns {string} - Blob 对象的 URL
 * @throws {Error} - 如果创建 URL 失败，则抛出异常
 */
export function createBlobURLFromUint8Array(data, type) {
    try {
        const blob = new Blob([data], { type });
        return createBlobURL(blob);
    } catch (error) {
        throw new Error('创建 URL 失败: ' + error.message);
    }
}

/**
 * 生成 Blob 对象的 URL，接受字符串或 Base64 数据
 * @param {string} data - 要创建 URL 的字符串或 Base64 数据
 * @param {string} [type] - Blob 的 MIME 类型
 * @returns {string} - Blob 对象的 URL
 * @throws {Error} - 如果创建 URL 失败，则抛出异常
 */
export function createBlobURLFromString(data, type) {
    try {
        let decodedData;

        // 如果是 Base64 数据，则解码
        if (/^data:/.test(data)) {
            const binaryString = atob(data.split(',')[1]);
            const arrayBuffer = new ArrayBuffer(binaryString.length);
            const uint8Array = new Uint8Array(arrayBuffer);

            for (let i = 0; i < binaryString.length; i++) {
                uint8Array[i] = binaryString.charCodeAt(i);
            }

            decodedData = uint8Array;
        } else {
            // 如果是字符串，则直接使用
            decodedData = data;
        }

        const blob = new Blob([decodedData], { type });
        return createBlobURL(blob);
    } catch (error) {
        throw new Error('创建 URL 失败: ' + error.message);
    }
}

/**
 * 释放 Blob 对象的 URL，
 * @param {string} url - 要释放的url
 */
export function revokeUrl(url) {
    (window.URL || window.webkitURL || window || {}).revokeObjectURL(url);
}

/**
 * 释放 Blob 对象的 URL，
 * @param {string[]} urls - 要释放的url
 */
export function revokeUrls(urls) {
    for (let i = 0; i < urls.length; i++) {
        (window.URL || window.webkitURL || window || {}).revokeObjectURL(urls[i]);
    }
}

/**
 * 获取滚动条位置
 * @param {string} id - 滚动条所在元素的id
 * @returns {number} - 当前滚动条位置
 */
export function getScrollPosition(id) {
    const element = document.getElementById(id);
    if (element) {
        const scrollTop = element.scrollTop;
        console.log(`Scroll position of ${id}: ${scrollTop}`);
        return scrollTop;
    } else {
        console.error(`Element with id ${id} not found.`);
        return null;
    }
}

/**
 * 修改滚动条位置
 * @param {string} id - 滚动条所在元素的id
 * @param {number} targetPosition - 目标滚动位置
 */
export function setScrollPosition(id, targetPosition) {
    const element = document.getElementById(id);
    if (element) {
        const currentPosition = element.scrollTop;
        const distance = targetPosition - currentPosition;
        const duration = 500; // 滚动时间（毫秒）

        // 添加样式实现平滑滚动
        element.style.transition = `scrollTop ${duration}ms ease-in-out`;

        // 修改滚动位置
        element.scrollTop = targetPosition;

        // 打印日志
        console.log(`Scrolling ${id} to ${targetPosition}`);

        // 在滚动完成后移除样式
        setTimeout(() => {
            element.style.transition = '';
        }, duration);
    } else {
        console.error(`Element with id ${id} not found.`);
    }
}

/**
 * 获取滚动条高度
 * @param {string} id - 滚动条所在元素的id
 * @returns {number} - 滚动条高度
 */
export function getScrollHeight(id) {
    const element = document.getElementById(id);
    if (element) {
        const scrollHeight = element.scrollHeight;
        console.log(`Scroll height of ${id}: ${scrollHeight}`);
        return scrollHeight;
    } else {
        console.error(`Element with id ${id} not found.`);
        return null;
    }
}


/**
 * 滚动到底部
 * @param {string} id - 滚动条所在元素的id
 */
export function scrollToBottom(id) {
    const element = document.getElementById(id);
    if (element) {
        const scrollHeight = element.scrollHeight;
        setScrollPosition(id, scrollHeight);
    } else {
        console.error(`Element with id ${id} not found.`);
    }
}

/**
* 滚动到滚动条顶部
* @param {string} id - 滚动条所在元素的id
*/
export function scrollToTop(id) {
    const element = document.getElementById(id);
    if (element) {
        setScrollPosition(id, 0);
    } else {
        console.error(`Element with id ${id} not found.`);
    }
}

/**
 * 复制文字到剪贴板
 * @param {string} text - 要复制的文字
 * @returns {Promise} - 返回一个Promise对象，表示复制操作的结果
 */
export function copyToClipboard(text) {
    return new Promise((resolve, reject) => {
        // 创建一个临时的textarea元素
        const textarea = document.createElement('textarea');
        textarea.value = text;
        textarea.setAttribute('readonly', '');
        textarea.style.position = 'absolute';
        textarea.style.left = '-9999px';
        document.body.appendChild(textarea);

        // 选中并复制文字
        textarea.select();
        document.execCommand('copy');

        // 清理临时元素
        document.body.removeChild(textarea);

        // 检查复制是否成功
        const success = document.execCommand('copy');
        if (!success) {
            console.error('Copy to clipboard failed.');
            return;
        }
        resolve();
    });
}

