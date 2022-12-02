pub trait Solution {
    fn name(&self) -> &'static str;
    fn solve_part_1(&self) -> i32;
    fn solve_part_2(&self) -> i32;
}