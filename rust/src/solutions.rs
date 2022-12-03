use crate::solution::year_2022::ALL_SOLUTIONS;
// use crate::solution::year_2023::ALL_SOLUTIONS;

mod year_2022;
mod year_2023;

pub trait Solution {    
    fn name(&self) -> &'static str;
    fn solve_part_1(&self, input: String) -> i32;
    fn solve_part_2(&self, input: String) -> i32;
}

pub fn get_solution(year: u32, day: u32) -> &'static Option<&'static dyn Solution>{
    // let aoc_year = match year {
    //     2022 => &year_2022::ALL_SOLUTIONS,
    //     2023 => &year_2023::ALL_SOLUTIONS,
    // };

    // let solution = match aoc_year.get(day) {
    //     Some(s) => s,
    //     None => {
    //         println!("No solution for day {} in year {}", day, year);
    //     }
    // };

    year_2022::ALL_SOLUTIONS.get(0)
    
    // PlaceholderSolution
}

pub struct PlaceholderSolution;

impl Solution for PlaceholderSolution {
    fn name(&self) -> &'static str {
        "Placeholder Solution"
    }

    fn solve_part_1(&self, input: String) -> i32 {
        1
    }

    fn solve_part_2(&self, input: String) -> i32 {
        2
    }
}
