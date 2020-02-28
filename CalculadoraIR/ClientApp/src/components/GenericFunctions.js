export const Val = (id)=> {
    return document.getElementById(id).value;
}
export const LimpaInputs = () => {
    let inputs = document.getElementsByTagName('input')
    for (let i = 0; i < inputs.length; i++) {
        inputs[i].value = '';
    }
}