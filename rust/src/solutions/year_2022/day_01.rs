use crate::solutions::Solution;

pub struct Day01;

impl Solution for Day01 {
    fn name(&self) -> &'static str {
        "Calorie Counting"
    }

    fn solve_part_1(&self, input: &str) -> i32 {
        let lines: Vec<&str> = input.lines().collect();

        // separate elf calorie lists by double newlines... can I slice?
        let mut elves: Vec<Elf> = Vec::new();

        // create new elves every time an empty lines is encountered
        for line in &lines {
            if line.is_empty() {
                // if line is empty, create new Elf and next
                // println!("empty line, creating new Elf");

                let mut elf = Elf {
                    food_items: Vec::new(),
                };

                elf.food_items.push(1000);

                elves.push(elf);
            } else {
                // if line is not empty, append to current Elf.food_items
                // println!("calorie value: {}", line)
            }
        }

        // dbg!(lines.len());
        // dbg!(elves.len());

        lines.len() as i32
    }

    fn solve_part_2(&self, input: &str) -> i32 {
        input.len() as i32
    }

    // fn build_elf(lines: Vec<&str>) -> Elf {
    //     elf = Elf { food_items: () }
    // }
}

struct Elf {
    food_items: Vec<u32>,
}

impl Elf {
    // fn get_calorie_total(&self) -> u32 {
    //     self.food_items.iter().sum()
    // }
}

#[cfg(test)]
mod tests_2022_01 {
    // use super::*;

    // TESTS:
    // - build elves
    // - get total calories
    // - get elf with max total calories

    #[test]
    fn input_into_elves() {
        let lines: Vec<&str> = TEST_INPUT.lines().collect();

        assert_eq!(14, lines.len());
    }

    const TEST_INPUT: &'static str = "\
1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";
}
