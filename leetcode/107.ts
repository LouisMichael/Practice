/**
 * Definition for a binary tree node.
 * class TreeNode {
 *     val: number
 *     left: TreeNode | null
 *     right: TreeNode | null
 *     constructor(val?: number, left?: TreeNode | null, right?: TreeNode | null) {
 *         this.val = (val===undefined ? 0 : val)
 *         this.left = (left===undefined ? null : left)
 *         this.right = (right===undefined ? null : right)
 *     }
 * }
 */
// breath first is doable as two queues but this might only be good as a dictionary?
function levelOrderBottom(root: TreeNode | null): number[][] {
    let levelMap = new Map<number,number[]>();
    let maxLevel = levelOrderBottomFillMap(root,0,levelMap);
    let ret = [];
    for(let i = maxLevel-1; i>=0;i--){
        ret.push(levelMap.get(i));
    }
    return ret;
};
function levelOrderBottomFillMap(root: TreeNode | null, level: number, map:Map<number,number[]>): number{
    if(root == null){
        return level;
    }
    if(!map.has(level)){
        map.set(level, []);
    }
    map.get(level).push(root.val);
    return Math.max(levelOrderBottomFillMap(root.left,level+1,map), levelOrderBottomFillMap(root.right,level+1,map));
    
}
