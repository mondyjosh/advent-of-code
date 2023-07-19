use crate::solutions::Solution;

pub struct Day02;

impl Solution for Day02 {
    fn name(&self) -> &'static str {
        "Rock Paper Scissors"
    }

    /// TODO: Returns the total score of the strategy guide's predictions
    fn solve_part_one(&self, input: &str) -> i32 {
        input.len() as i32
    }

    /// TODO: Returns the solution for part one
    fn solve_part_two(&self, input: &str) -> i32 {
        (input.len() + 1) as i32
    }
}

#[cfg(test)]
mod tests_2022_02 {
    // use super::*;

//     const TEST_INPUT: &'static str = "\
// A Y
// B X
// C Z";
}
