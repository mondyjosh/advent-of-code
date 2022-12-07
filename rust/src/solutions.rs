mod year_2022;

pub trait Solution {
    fn name(&self) -> &'static str;
    fn solve_part_1(&self, input: &str) -> i32;
    fn solve_part_2(&self, input: &str) -> i32;
}

pub fn get_solution(year: u32, day: u32) -> Option<&'static &'static dyn Solution> {
    // TODO: Handle throwaway (_)
    let aoc_year: &[&dyn Solution] = match year {
        2022 => &year_2022::ALL_SOLUTIONS,        
        _ => todo!(),
    };

    // Adjust to zero-index
    aoc_year.get((day - 1) as usize)
}
