/**
 * document 工具类，提供一些常用的 document 操作方法 
 */

/**
 * 点击指定id的元素
 * @param id
 */
export function clickDocument(id) {
    const element = document.getElementById(id);
    if (element) {
        element.click();
    } else {
        console.error(`Element with id ${id} not found.`);
    }
}

/**
 * 点击指定的元素
 * @param element
 */
export function clickElement(element) {
    if (element) {
        element.click();
    } else {
        console.error(`Element is null.`);
    }
}

/**
 * 获取指定id的元素
 */
export function getElementById(id) {
    return document.getElementById(id);
}

/**
 * 判断指定id的元素是否存在
 */
export function hasElementById(id) {
    return document.getElementById(id) !== null;
}

