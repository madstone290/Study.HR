export class AntFormItemProps {
    /**
     * 
     * @param {object} item
     * @param {string} item.name
     * @param {string} item.label 
     * @param {object[]} item.rules
     * @param {boolean} item.rules.required
     * @param {string} item.rules.message
     * @param {string} item.rules.type
     * @param {string} item.tooltip
     * @param {boolean} item.hasFeedback
     * @param {string[]} item.dependencies
     */
    constructor({ name, label, tooltip, hasFeedback, dependencies, rules }) {
        this.name = name;
        this.label = label;
        this.tooltip = tooltip;
        this.hasFeedback = hasFeedback;
        this.dependencies = dependencies;
        this.rules = rules;
    }
}